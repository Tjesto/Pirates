using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
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

        protected abstract List<MapElement> generateMap();
        protected abstract List<NatureElement> generateEnvironment();
        protected abstract List<Ship> generateShips();
    }
}
