using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    class MapModel
    {
        List<OnMapElementAddedListener> listeners;

        public MapModel()
        {            
            listeners = new List<OnMapElementAddedListener>();
            createMap();
        }

        public MapModel(OnMapElementAddedListener listener)
        {
            listeners = new List<OnMapElementAddedListener>();
            addListener(listener);
            createMap();
        }

        private void createMap()
        {
            Map.getInstance(this);
        }

        public void addListener(OnMapElementAddedListener listener)
        {
            listeners.Add(listener);
        }

        public void removeListener(OnMapElementAddedListener listener)
        {
            listeners.Remove(listener);
        }

        public void cleanListeners()
        {
            listeners.Clear();
        }

        internal void notifyElementAdded(MapElement element)
        {
            foreach (OnMapElementAddedListener listener in listeners)
            {
                listener.onElementAdded(element);
            }
        }
    }
}
