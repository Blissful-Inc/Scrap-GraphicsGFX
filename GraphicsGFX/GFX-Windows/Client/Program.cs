using System;

namespace GFXWrapper.Client
{
    internal class Program : System.Windows.Application, IDisposable
    {
        #region // ctor

        public Program()
        {
            Startup += (sender, args) => Ctor();
            Exit += (sender, args) => Dispose();
        }

        private void Ctor()
        {
            var readOnlyList = WindowFactory.SeedWindows(); 

        }

        public void Dispose()
        {

        }


        #endregion





    }
}
