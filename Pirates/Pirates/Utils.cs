using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.GameObjects;
using Pirates.GameObjects.Map;
using Pirates.Windows;

namespace Pirates
{
    enum AccessMode
    {
        DEBUG_MENU, DEBUG_GAME, DEBUG_GAME_MENU, DEBUG, RELEASE
    }

    sealed class Pair<First, Second>
    {
        public First first { set; get; }
        public Second second { set; get; }

        private Pair(First first, Second second) 
        {
            this.first = first;
            this.second = second;
        }

        public static Pair<First, Second> createPairOf(First first, Second second)
        {
            return new Pair<First, Second>(first, second);
        }
        
        public override bool Equals (object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType()) 
            {
                return false;
            }
            Pair<First, Second> pair = (Pair<First, Second>) obj;

            return (this.first.Equals(pair.first) && this.second.Equals(pair.second)); 
        }   
        
    }

    class Utils
    {
        public static bool DEBUG = true;
        public static bool TESTS = false;
        public static MapFactoryType GAME_MAP = MapFactoryType.TEST;
        public static AccessMode ACCESS_MODE = AccessMode.DEBUG_GAME;

        internal static System.Windows.Forms.Form getDefaultStartPoint()
        {
            return new MainMenuWindow();
        }

        internal static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        internal static System.Drawing.Color getLandColor()
        {
            if (GAME_MAP == MapFactoryType.TEST)
            {
                return System.Drawing.Color.DarkGoldenrod;
            }

            return System.Drawing.Color.DarkGoldenrod;
        }

        internal static bool checkAngle(float angle, int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                minValue -= 360;
            }

            return (angle >= minValue && angle < maxValue);
        }

        internal static float dpToPx(int p)
        {
            return p * Pirates.Rendering.ViewPortHelper.getInstance().right / 1024;
        }
        
    }
}
