using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.GameObjects.Map;

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

        public override string ToString()
        {
            return "Current location: " + left + "x" + top + " ends: " + right + "x" + bottom;
        }


        internal static bool isIn(Location bigger, Location smaller, out CollisionType type)
        {
            bool isIn = true;
            isIn &= bigger.top < smaller.top;
            isIn &= bigger.top < smaller.bottom;
            type = isIn ? CollisionType.NONE : CollisionType.TOP;
            isIn &= bigger.bottom > smaller.top;
            isIn &= bigger.bottom > smaller.bottom;
            type = isIn ? CollisionType.NONE : (type == CollisionType.NONE ? CollisionType.BOTTOM : type);
            isIn &= bigger.left < smaller.left;
            isIn &= bigger.left < smaller.right;
            type = isIn ? CollisionType.NONE : (type == CollisionType.NONE ? CollisionType.LEFT : type);
            isIn &= bigger.right > smaller.left;
            isIn &= bigger.right > smaller.right;
            type = isIn ? CollisionType.NONE : (type == CollisionType.NONE ? CollisionType.RIGHT : type);

            return isIn;
        }

        internal static bool isOutOf(Location a, Location b, out CollisionType type)
        {
            bool isOut;
            //b.left || b.right is between a.left && a.right, a.top < b.top a.bottom < a.top
            isOut = ((b.left > a.left && b.left < a.right) || (b.right > a.left && b.right < a.right) && a.top < b.top && a.bottom < a.top);
            if (isOut)
            {
                if (Math.Abs(a.top - b.top) < Math.Abs(b.top - a.bottom))
                {
                    type = CollisionType.TOP;
                }
                else
                {
                    type = CollisionType.BOTTOM;
                }
                return false;
            }
            else
            {
                type = CollisionType.NONE;
            }
            return true;
        }

        internal bool containsPoint(int x, int y)
        {
            return (left < x && right > x || top < y && bottom > y);
        }
    }
}
