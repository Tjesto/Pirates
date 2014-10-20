using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.Rendering
{
    class MapUtils
    {
        public class ARGBColor
        {
            public int Alpha
            {
                get;
                set;
            }
            public int Red
            {
                get;
                set;
            }
            public int Green
            {
                get;
                set;
            }
            public int Blue
            {
                get;
                set;
            }
        
            public ARGBColor(int Alpha, int Red, int Green, int Blue)
            {
                this.Alpha = Alpha;
                this.Red = Red;
                this.Green = Green;
                this.Blue = Blue;
            }
        }

        public const int NON_TRANSPARENT_ALPHA = 0xFF;        

        public static ARGBColor BackgroundARGBColor
        {
            get {
                return new ARGBColor(NON_TRANSPARENT_ALPHA, 0x33, 0x66, 0x66);
            }   
        }
    }
}
