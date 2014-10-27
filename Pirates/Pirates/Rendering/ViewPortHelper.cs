using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.Rendering
{
    class ViewPortHelper
    {
        public float left { set; get; }
        public float right { set; get; }
        public float top { set; get; }
        public float bottom { set; get; }

        protected static ViewPortHelper instance;

        protected ViewPortHelper(float left, float top, float right, float bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }


        public static ViewPortHelper getInstance(float left, float top, float right, float bottom)
        {
            if (instance == null)
            {
                instance = new ViewPortHelper(left, top, right, bottom);
            }

            return instance;
        }

        public static ViewPortHelper getInstance()
        {
            if (instance == null)
            {
                throw new NullReferenceException("No instance created");
            }

            return instance;
        }
    }
}

