using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    class MapBoard : MapElement
    {
        private Bitmap map;

        private Location location;

        private static MapBoard board;

        public static void createMapBoard(Location startLocation, Bitmap map) 
        {
            if (board == null)
            {
                board = new MapBoard(startLocation, map);
            }
        }

        public static MapBoard getInstance()
        {
            if (board == null)
            {
                throw new InvalidOperationException("MapBoard has not been created yet");
            }
            return board;
        }

        protected MapBoard(Location startLocation, Bitmap map)
        {
            this.map = map;
            location = startLocation;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(map, location.left, location.top);
        }

        public void refreshVisibilityTowards(float[] move)
        {
            Log.d("map board", "move to new location");
            location.move(move[0], move[1]);
        }

        public int getLevel()
        {
            return 1;
        }

        public Location getLocation()
        {
            return location;
        }
    }
}
