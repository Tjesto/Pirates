using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    class Map
    {
        protected static Map instance;

        protected Dictionary<int, List<MapElement>> objectsToRender = new Dictionary<int,List<MapElement>>();

        protected Map()
        {
            AbstractMapFactory factory = AbstractMapFactory.createMapFactory(Utils.GAME_MAP);
        }

        public static Map getInstance()
        {
            if (instance == null)
            {
                instance = new Map();
            }

            return instance;
        }

        public SortedList<int, MapElement> getMapElementsInCamera()
        {
            SortedList<int, MapElement> elementsInCamera = new SortedList<int, MapElement>();

            return elementsInCamera;
        }

        public void onMapElementAdded(MapElement mapElement)
        {
            if (objectsToRender != null)
            {
                if (!objectsToRender.ContainsKey(mapElement.getLevel()))
                {
                    objectsToRender.Add(mapElement.getLevel(), new List<MapElement>());
                }
                List<MapElement> elements = new List<MapElement>();
                if (objectsToRender.TryGetValue(mapElement.getLevel(), out elements))
                {
                    elements.Add(mapElement);
                }
            }
        }
    }
}
