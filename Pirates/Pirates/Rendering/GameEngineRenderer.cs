using Pirates.GameObjects;
using Pirates.GameObjects.Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pirates.GameObjects.Map;

namespace Pirates.Rendering
{
    class GameEngineRenderer : OnMapElementAddedListener
    {
        private MainWindow window;
        private Thread mainGameThread;
        private bool rendering;

        private volatile Dictionary<int, List<MapElement>> objectsToRender;
        private volatile List<TerrainObject> terrainObjects;
        private volatile List<Ship> ships;
        private volatile List<NatureElement> enviromentObjects;
        private volatile float testX, testY;
        private volatile MapModel model;
        private PlayersInfo playerInfo {get;set;}

        public GameEngineRenderer(MainWindow window)
        {
            this.window = window;
            mainGameThread = new Thread(startGameLoop);
            rendering = false;
            terrainObjects = new List<TerrainObject>();
            ships = new List<Ship>();
            enviromentObjects = new List<NatureElement>();
            model = new MapModel(this);            
            
            playerInfo = new PlayersInfo();
            model.notifyElementAdded(playerInfo.playersShip);
            testX = 0;
            testY = 0;            
        }

        public void addTerrain(TerrainObject terrainObject)
        {
            terrainObjects.Add(terrainObject);      
        }

        public void addShip(Ship ship)
        {
            ships.Add(ship);
        }

        public void addNature(NatureElement natureElement)
        {
            enviromentObjects.Add(natureElement);
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
         * Method for testing purposes
         * returns objects to render if it's for test or for debug. Otherwise returns null
         */
        public Dictionary<int, List<MapElement>> getObjectsToRender()
        {
            if (Utils.TESTS || Utils.DEBUG)
            {
                return objectsToRender;
            }
            return null;
        }

        /**
         * Method for testing purposes
         * returns terrain objects if it's for test or for debug. Otherwise returns null
         */
        public List<TerrainObject> getTerrain()
        {
            if (Utils.TESTS || Utils.DEBUG)
            {
                return terrainObjects;
            }
            return null;
        }

        /**
         * Method for testing purposes
         * returns shils if it's for test or for debug. Otherwise returns null
         */
        public List<Ship> getShips()
        {
            if (Utils.TESTS || Utils.DEBUG)
            {
                return ships;
            }
            return null;
        }

        /**
         * Method for testing purposes
         * returns enviroment objects if it's for test or for debug. Otherwise returns null
         */
        public List<NatureElement> getEnviroment()
        {
            if (Utils.TESTS || Utils.DEBUG)
            {
                return enviromentObjects;
            }
            return null;
        }

        public void stopMainGameLoop()
        {
            rendering = false;
            mainGameThread.Abort();
        }

        public void onElementAdded(MapElement e)
        {
            if (e is TerrainObject)
            {
                addTerrain((TerrainObject) e);
            }
            else if (e is Ship)
            {
                addShip((Ship) e);
            }
            else if (e is NatureElement)
            {
                addNature((NatureElement) e);
            }
        }

        public void invalidateMap(Graphics g)
        {            
            SortedList<int, MapElement> elementsInViewport = Map.getInstance().getMapElementsInCamera();
            foreach (MapElement e in elementsInViewport.Values)
            {
                e.draw(g);
            }            
        }
    }
}
