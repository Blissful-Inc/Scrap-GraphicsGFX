using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using GFXWrapper.Engine.Render;


namespace GFXWrapper.Client
{
    public static class WindowFactory
    {
        public static IReadOnlyList<IRenderHost> SeedWindows()
        {
            var size = new System.Drawing.Size(720, 480);


            var renderHost = new[]
            {
                CreateWindowForm(size, "Forms Gdi", h => new RenderHost(h))
            };

            return renderHost;
        }

        private static IRenderHost CreateWindowForm(System.Drawing.Size size, string title, Func<IntPtr, IRenderHost> ctorRenderHost)
        {
            var window = new System.Windows.Forms.Form()
            {
                Size = size,
                Text = title,
            };

            var hostControl = new System.Windows.Forms.Panel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.Transparent,
            };

            window.Controls.Add(hostControl);

            hostControl.MouseEnter += (sender, args) =>
            {
                if (System.Windows.Forms.Form.ActiveForm != window) window.Activate();
                if (!hostControl.Focused) hostControl.Focus();
            };

            window.Closed += (sender, args) => System.Windows.Application.Current.Shutdown();

            window.Show();

            return ctorRenderHost(hostControl.Handle);

        }
    }

    private static IRenderHost CreateWindowWpf(System.Drawing.Size size, string title, Func<IntPtr, IRenderHost> ctorRenderHost)
    {
        var window = System.Windows.Window
        {
            Width = size.Width,
            Height = size.Height, 
            Title = title,
        };

        var hostControl = System.Windows.Controls.Grid
        {
            Background = System.Windows.Media.Brushes.Transparent,
            Focusable = true,
        };

        window.Content = hostControl;


        hostControl.MouseEnter += (sender, args) =>
        {
            if (!window.IsActive) window.Activate();
            if (!hostControl.IsFocused) hostControl.Focus();
        };

        window.Closed += (sender, args) => System.Windows.Application.Current.Shutdown();
        window.Show();
        return ctorRenderHost(hostControl.handle)


    }

}
