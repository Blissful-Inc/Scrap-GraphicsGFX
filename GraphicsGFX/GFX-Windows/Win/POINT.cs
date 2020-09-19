using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFXWrapper.Win
{
    public struct POINT
    {
        public int X, Y;

        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public POINT(System.Drawing.Point pt) : this (pt.X, pt.Y)
        {
        }

        public static implicit operator System.Drawing.Point(POINT p) => new System.Drawing.Point(p.X, p.Y);

        public static implicit operator POINT(System.Drawing.Point p) => new POINT(p.X, p.Y);
    }
}
