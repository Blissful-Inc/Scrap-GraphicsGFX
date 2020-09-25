using GFXWrapper.Engine.Render;
using GFXWrapper.U;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GFXWrapper.Client
{
    internal class Program : System.Windows.Application, IDisposable
    {

        #region // storage

        private IReadOnlyList<IRenderHost> RenderHosts { get; set; }

        #endregion

        #region // ctor

        public Program()
        {
            Startup += (sender, args) => Ctor();
            Exit += (sender, args) => Dispose();
        }

        private void Ctor()
        {
            var readOnlyList = WindowFactory.SeedWindows();

            // create some render hosts for rendering
            RenderHosts = WindowFactory.SeedWindows();

            // render loop
            while (!Dispatcher.HasShutdownStarted)
            {
                Render(RenderHosts);
                System.Windows.Forms.Application.DoEvents();
            }

        }

        public void Dispose()
        {

            RenderHosts.ForEach(host => host.Dispose());
            RenderHosts = default;

        }


        #endregion


        #region // render

        private static void Render(IEnumerable<IRenderHost> renderHosts)
        {
            renderHosts.ForEach(rh => rh.Render());

        }


        #endregion




    }
}
