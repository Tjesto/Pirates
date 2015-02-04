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

        public bool canDock { get; set; }

        private Dictionary<Pair<int, int>, CityObject> cities;

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
            cities = new Dictionary<Pair<int, int>, CityObject>();
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

        public void addCity(int x, int y, CityObject city)
        {
            Pair<int, int> key = Pair<int, int>.createPairOf(x, y);
            cities.Add(key, city);            
        }


        internal bool isBlocked(int p1, int p2, out int collisionPortId)
        {
            bool isPortVar = isPort(p1, p2, out collisionPortId);
            return mapBoard[p1, p2] == FieldType.LAND || isPortVar;
        }

        internal bool isPort(int p1, int p2, out int collisionPortId)
        {
            canDock = mapBoard[p1, p2] == FieldType.CITY;
            int id = -1;
            if (canDock)
            {
                CityObject c;
                cities.TryGetValue(Pair<int, int>.createPairOf(p1, p2), out c);                
            }
            collisionPortId = id;
            return canDock;
        }

        internal string getPortName()
        {
            return "Nazwa Tymczasowa";
        }
    }
}
