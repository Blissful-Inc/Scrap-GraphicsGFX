using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFXWrapper.Drivers.Gdi.Render
{
    public class RenderHost : Engine.Render.RenderHost
    {
        public RenderHost(IntPtr hostHandle) : base(hostHandle)
        {
        }
    }
}
