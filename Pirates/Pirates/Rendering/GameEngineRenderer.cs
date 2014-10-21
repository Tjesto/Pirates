using Pirates.GameObjects;
using Pirates.GameObjects.Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pirates.Rendering
{
    class GameEngineRenderer
    {
        private MainWindow window;
        private Thread mainGameThread;
        private bool rendering;

        private volatile Dictionary<int, List<MapElement>> objectsToRender;
        private volatile List<TerrainObject> terrainObjects;
        private volatile List<Ship> ships;
        private volatile List<NatureElement> enviromentObjects;
        private volatile float testX, testY;
        private PlayersInfo playerInfo {get;set;}

        public GameEngineRenderer(MainWindow window)
        {
            this.window = window;
            mainGameThread = new Thread(startGameLoop);
            rendering = false;
            terrainObjects = new List<TerrainObject>();
            ships = new List<Ship>();
            enviromentObjects = new List<NatureElement>();
            objectsToRender = new Dictionary<int,List<MapElement>>();
            playerInfo = new PlayersInfo();
            testX = 0;
            testY = 0;            
        }

        public void addTerrain(TerrainObject terrainObject)
        {
            terrainObjects.Add(terrainObject);
            onMapElementAdded(terrainObject);
        }

        private void onMapElementAdded(MapElement mapElement)
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

        public void startMainGameLoop()
        {
            rendering = true;
            mainGameThread.Start();
        }

        void startGameLoop()
        {
            while (rendering)
            {
                //Players input refresh state
                   
                //Refreshing elements visibility and position
                foreach (MapElement e in terrainObjects)
                {
                    e.refreshVisibilityTowards(playerInfo.playersShip);
                }

                foreach (Ship sh in ships)
                {
                    sh.refresh();
                    if (!(sh.Equals(playerInfo.playersShip))) 
                    {
                        sh.refreshVisibilityTowards(playerInfo.playersShip);
                    }                    
                }
                
                foreach (NatureElement n in enviromentObjects)
                {
                    n.refreshVisibilityTowards(playerInfo.playersShip);
                }
                testX += 0.001f;
                testY += 0.001f;
                if (testX > 500) testX = 0;
                if (testY > 500) testY = 0;
            }
        }
        /**
         * 
         * 
         */
        public Dictionary<int, List<MapElement>> getObjectsToRender()
        {
            return objectsToRender;
        }

        public void stopMainGameLoop()
        {
            rendering = false;
            mainGameThread.Abort();
        }

        public void invalidateElements(Graphics g)
        {
            foreach (MapElement e in terrainObjects)
            {
                e.draw(g);
            }

            foreach (Ship sh in ships)
            {
                sh.draw(g);
            }

            foreach (NatureElement n in enviromentObjects)
            {
                n.draw(g);
            }
            g.DrawEllipse(new Pen(Color.CadetBlue), testX, testY, 10, 10);
        }
    }
}
