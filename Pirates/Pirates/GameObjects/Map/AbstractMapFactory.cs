using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public abstract List<MapElement> generateMap();
        public abstract List<NatureElement> generateEnvironment();
        public abstract List<Ship> generateShips();        
    }
}
