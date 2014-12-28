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
    }
}
