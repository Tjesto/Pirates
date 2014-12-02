using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    class TestMapFactory : AbstractMapFactory
    {

        public override List<MapElement> generateMap()
        {
            List<MapElement> elements = new List<MapElement>();
            parseMap(elements, Properties.Resources.test_map1);
            Bitmap map = Properties.Resources.test_map;
            MapBoard.createMapBoard(new Location(-map.Width/2, -map.Height/2, map.Width/2, map.Height/2), map);
            elements.Add(MapBoard.getInstance());
            Log.d("map factory", elements.Contains(MapBoard.getInstance()) + "");
            return elements;
        }

        
        public override List<NatureElement> generateEnvironment()
        {
            List<NatureElement> elements = new List<NatureElement>();
            //add nature elements
            return elements;
        }
        public override List<Ship> generateShips()
        {
            List<Ship> ships = new List<Ship>();
            //add ships
            return ships;
        }    
    }
}
