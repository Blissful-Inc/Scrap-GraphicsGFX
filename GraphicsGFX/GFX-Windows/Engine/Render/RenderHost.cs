using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFXWrapper.Engine.Render
{
    public class RenderHost : IRenderHost
    {

        #region // storage

        public IntPtr HostHandle { get; private set; }

        #endregion

        #region // ctor

        public RenderHost(IntPtr hostHandle)
        {
            HostHandle = hostHandle;

        }

        public void Dispose()
        {
            HostHandle = default;
        }



        #endregion

    }
}
