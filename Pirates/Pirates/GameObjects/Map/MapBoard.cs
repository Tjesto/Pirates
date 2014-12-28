using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    class MapBoard : MapElement
    {
        private Bitmap map;

        private Location location;

        private FieldType[,] mapBoard;

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
            this.mapBoard = new FieldType[160,120];
        }

        public void draw(Graphics g)
        {
            //Log.d("MapBoard", location.ToString());
            //g.DrawImage(map, location.left, location.top);
            g.DrawRectangle(new Pen(Color.DarkBlue, 1), location.left, location.top, 1600, 1200);
        }

        public void refreshVisibilityTowards(float[] move)
        {
            //Log.d("map board", "move to new location");
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

        public void add(int x, int y, FieldType value)
        {
            mapBoard[x, y] = value;
        }


        internal bool isBlocked(int p1, int p2)
        {
            return mapBoard[p1, p2] == FieldType.LAND;
        }
    }
}
