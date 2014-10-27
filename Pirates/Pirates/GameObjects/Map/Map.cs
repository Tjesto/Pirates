using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.Rendering;

namespace Pirates.GameObjects.Map
{

    interface OnMapElementAddedListener
    {
        void onElementAdded(MapElement e);
    }

    class Map : OnMapElementAddedListener
    {        
        protected static Map instance;

        protected Dictionary<int, List<MapElement>> objectsToRender = new Dictionary<int,List<MapElement>>();

        protected Map(MapModel model)
        {
            AbstractMapFactory factory = AbstractMapFactory.createMapFactory(Utils.GAME_MAP);
            model.addListener(this);
            foreach(MapElement element in factory.generateMap())
            {
                model.notifyElementAdded(element);
            }

            foreach (MapElement element in factory.generateShips())
            {
                model.notifyElementAdded(element);
            }

            foreach (MapElement element in factory.generateEnvironment())
            {
                model.notifyElementAdded(element);
            }
        }

        public static Map getInstance()
        {
            if (instance == null)
            {
                throw new NullReferenceException("No instance created yet");
            }

            return instance;
        }

        public static Map getInstance(MapModel model)
        {
            if (instance == null)
            {
                instance = new Map(model);
            }

            return instance;
        }

        public SortedList<int, MapElement> getMapElementsInCamera()
        {
            SortedList<int, MapElement> elementsInCamera = new SortedList<int, MapElement>();

            int i = 0;
            foreach (int level in objectsToRender.Keys)
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
            return mapElement.getLocation().
                isInRect(ViewPortHelper.getInstance().left, ViewPortHelper.getInstance().top, 
                ViewPortHelper.getInstance().right, ViewPortHelper.getInstance().bottom);
        }

        public void onElementAdded(MapElement mapElement)
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
