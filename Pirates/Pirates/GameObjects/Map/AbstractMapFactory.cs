using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.Rendering;

using System.Windows.Forms;

namespace Pirates.GameObjects.Map
{
    enum MapFactoryType { CARRIBEAN, TEST }

    abstract class AbstractMapFactory
    {

        public static AbstractMapFactory createMapFactory(MapFactoryType mapType)
        {
            switch (mapType)
            {
                case MapFactoryType.CARRIBEAN: return new CarribeanMapFactory();
                case MapFactoryType.TEST: return new TestMapFactory();
                default:
                    return new TestMapFactory();
            }
        }

        protected void parseMap(List<MapElement> elements, byte[] resoruce)
        {
            string mapResource = System.Text.Encoding.Default.GetString(resoruce);
            string[] points = mapResource.Split('\n');
            for (int i = 1; i < points.Length; i++)
            {
                string[] currentPointObject = points[i].Split(new char[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                string[] location = currentPointObject[1].Split(',');
                string[] size = currentPointObject[2].Split('x');

                float left = float.Parse(location[0]);
                float top = float.Parse(location[1]);
                float right = float.Parse(size[0]) + left;
                float bottom = float.Parse(size[1]) + top;

                Location l = new Location(left, top, right, bottom);
                int level = 2;
                String name = currentPointObject[3].Replace('_', ' ').Replace('\r', '\0');
                elements.Add(new TerrainObject(level, l, name));
            }
            
        }

        public abstract List<MapElement> generateMap();
        public abstract List<NatureElement> generateEnvironment();
        public abstract List<Ship> generateShips();
    }
}
