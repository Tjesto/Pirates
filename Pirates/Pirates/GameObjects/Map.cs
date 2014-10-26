using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.Rendering;

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

            int i = 0;
            foreach (int level in objectsToRender.Keys)//; level < Utils.MAX_LEVEL; level++)
            {
                List<MapElement> elements = new List<MapElement>();
                if (objectsToRender.TryGetValue(level, out elements))
                {                    
                    foreach (MapElement e in elements)
                    {
                        if (checkLocation(e))
                        {
                            elementsInCamera.Add(i++, e);
                        }
                    }
                }
            }
            return elementsInCamera;
        }

        private bool checkLocation(MapElement mapElement)
        {
            bool result = false;
            result |= mapElement.getLocation(MapElementCorner.LEFT_TOP).isInRect(ViewPortHelper.getInstance().left, ViewPortHelper.getInstance().top, ViewPortHelper.getInstance().right, ViewPortHelper.getInstance().bottom);
            result |= mapElement.getLocation(MapElementCorner.LEFT_BOTTOM).isInRect(ViewPortHelper.getInstance().left, ViewPortHelper.getInstance().top, ViewPortHelper.getInstance().right, ViewPortHelper.getInstance().bottom);
            result |= mapElement.getLocation(MapElementCorner.RIGHT_TOP).isInRect(ViewPortHelper.getInstance().left, ViewPortHelper.getInstance().top, ViewPortHelper.getInstance().right, ViewPortHelper.getInstance().bottom); ;
            result |= mapElement.getLocation(MapElementCorner.RIGHT_BOTTOM).isInRect(ViewPortHelper.getInstance().left, ViewPortHelper.getInstance().top, ViewPortHelper.getInstance().right, ViewPortHelper.getInstance().bottom); ;
            return result;
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
