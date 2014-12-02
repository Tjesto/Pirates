using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    class Location
    {
        public float left { set; get; }

        public float top { set; get; }

        public float right { set; get; }

        public float bottom { set; get; }   

        public Location(float left, float top, float right, float bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public bool isInRect(float left, float top, float right, float bottom)
        {
            return (((this.left > left && this.left < right) || (this.right > left && this.right < right)) &&
                ((this.top > top && this.top < bottom) || (this.bottom > top && this.bottom < bottom)));
        }


        internal void move(float dx, float dy)
        {
            left -= dx;
            top += dy;
            right -= dx;
            bottom += dy;
        }
    }
}
