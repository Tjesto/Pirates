using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    class CarribeanMapFactory : AbstractMapFactory
    {

        public override List<MapElement> generateMap()
        {
            List<MapElement> elements = new List<MapElement>();
            //add map elements
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
