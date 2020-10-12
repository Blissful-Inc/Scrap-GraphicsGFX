using GFXWrapper.Engine.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFXWrapper.Drivers.Gdi.Render
{
    /// <summary>
    /// Gdi render host.
    /// </summary>
    public class RenderHost :
        Engine.Render.RenderHost
    {
        #region // storage

        /// <summary>
        /// Graphics retrieved from <see cref="IRenderHost.HostHandle"/>.
        /// </summary>
        private Graphics GraphicsHost { get; set; }

        /// <summary>
        /// Font for drawing text with <see cref="System.Drawing"/> objects.
        /// </summary>
        private Font FontConsolas12 { get; set; }

        #endregion

        #region // ctor

        /// <summary>
        /// Constructor.
        /// </summary>
        public RenderHost(IntPtr hostHandle) :
            base(hostHandle)
        {
            GraphicsHost = Graphics.FromHwnd(HostHandle);

            FontConsolas12 = new Font("Consolas", 12);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            FontConsolas12.Dispose();
            FontConsolas12 = default;

            GraphicsHost.Dispose();
            GraphicsHost = default;

            base.Dispose();
        }

        #endregion

        #region // render

        /// <inheritdoc />
        protected override void RenderInternal()
        {
            GraphicsHost.Clear(Color.Black);
            GraphicsHost.DrawString(FpsCounter.FpsString, FontConsolas12, Brushes.Red, 0, 0);
        }

        #endregion
    }
}
