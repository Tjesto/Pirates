using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.Rendering;

using System.Windows.Forms;
using Base;

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

            /*for (int i = 1; i < points.Length; i++)
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
            */
            for (int i = 0; i < 160; i++)
            {
                string[] line = points[i].Split('#');
                for (int j = 0; j < 120; j++)
                {
                    string[] f = line[j].Split(':');
                    if (f.Length < 2)
                        MessageBox.Show(line[j] + ";; " + f.Length + "\n" + j + "x" +i);
                    string fieldValue = f[1];
                    FieldType type = (FieldType) int.Parse(fieldValue);
                    MapBoard.getInstance().add(i, j, type);
                    if (type != FieldType.WATER)
                    {
                        float left = i * 10 + MapBoard.getInstance().getLocation().left;
                        float top = j * 10 + MapBoard.getInstance().getLocation().top; ;
                        elements.Add(new TerrainObject(20, new Location(left, top, left + 10, top + 10), ""));
                    }
                }
            }

        }

        public abstract List<MapElement> generateMap();
        public abstract List<NatureElement> generateEnvironment();
        public abstract List<Ship> generateShips();
    }
}
