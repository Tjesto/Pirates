using Pirates.GameObjects;
using Pirates.GameObjects.Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pirates.GameObjects.Map;
using Pirates.Windows;

namespace Pirates.Rendering
{
    class GameEngineRenderer : OnMapElementAddedListener
    {
        enum GameEngineRendererMode {
            SEA,
            PORT,
            FIGHT
        }

        private MainWindow window;
        private Thread mainGameThread;
        private bool rendering;

        private volatile Dictionary<int, List<MapElement>> objectsToRender;
        private volatile List<TerrainObject> terrainObjects;
        private volatile List<Ship> ships;
        private volatile List<NatureElement> enviromentObjects;
        private volatile List<CityObject> cities;
        private volatile MapBoard mapBoard;
        private volatile float testX, testY;
        private volatile MapModel model;
        public PlayersInfo playerInfo {get;set;}

        private GameEngineRendererMode currrentRenderingMode { set; get; }

        public GameEngineRenderer(MainWindow window)
        {
            this.window = window;
            mainGameThread = new Thread(startGameLoop);
            rendering = false;
            terrainObjects = new List<TerrainObject>();
            cities = new List<CityObject>();
            ships = new List<Ship>();
            enviromentObjects = new List<NatureElement>();
            model = new MapModel(this);            
            currrentRenderingMode = GameEngineRendererMode.SEA;
            
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
                if (Map.getInstance().forcePause)
                {
                    //DialogResult r = MessageBox.Show("Czy chcesz wpłynąć do portu " + MapBoard.getInstance().getPortName(), "", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                    window.pause();
                    currrentRenderingMode = GameEngineRendererMode.PORT;
                    //DockWindow dock = DockWindow.showWindow();                    
                    DialogResult r = window.DialogResult;
                    if (r != DialogResult.None)
                    {
                        Map.getInstance().portDecided = true;
                        Map.getInstance().forcePause = false;
                        Map.getInstance().saveCurrentAskAngle(playerInfo.playersAngle);
                        playerInfo.setAngleToGoOut();
                        Map.getInstance().isInPort = false;
                        currrentRenderingMode = GameEngineRendererMode.SEA;
                        window.resume();
                    }
                    continue;
                }
                float[] move;
                playerInfo.playersShip.azimuth = playerInfo.playersAngle;
                if (Map.getInstance().isCollisionDetected(playerInfo))
                {
                    Log.d("Renderer", "Collision detected");
                    move = Map.getInstance().getCollisionRosolution();
                }
                else
                {                    
                    move = playerInfo.move();
                }
                //Refreshing elements visibility and position
                //mapBoard.refreshVisibilityTowards(move);
                foreach (MapElement e in terrainObjects)
                {
                    e.refreshVisibilityTowards(move);
                }
                MapBoard.getInstance().refreshVisibilityTowards(move);
                foreach (Ship sh in ships)
                {
                    sh.refresh();
                    if (!(sh.Equals(playerInfo.playersShip))) 
                    {                        
                        sh.refreshVisibilityTowards(move);
                    }                    
                }
                
                foreach (NatureElement n in enviromentObjects)
                {
                    n.refreshVisibilityTowards(move);
                }

                Thread.Sleep(25);
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
            else if (e is CityObject)
            {
                addCity((CityObject) e);
            }            
            else if (e is Ship)
            {
                addShip((Ship) e);
            }
            else if (e is NatureElement)
            {
                addNature((NatureElement) e);
            }
            else if (e is MapBoard)
            {
                mapBoard = (MapBoard) e;
            }
        }

        private void addCity(CityObject cityObject)
        {
            cities.Add(cityObject);
        }

        public void invalidateMap(Graphics g)
        {
            float right = ViewPortHelper.getInstance().right;
            float bottom = ViewPortHelper.getInstance().bottom;
            int linesV = (int) (ViewPortHelper.getInstance().right / 10);
            int linesH = (int) (ViewPortHelper.getInstance().bottom / 10);

            switch (currrentRenderingMode) {
                case GameEngineRendererMode.FIGHT:
                    break;
                case GameEngineRendererMode.PORT:
                    break;
                case GameEngineRendererMode.SEA:
                    invalidateMapSeaMode(g);
                    break;
            }
            
        }

        private void invalidateMapSeaMode(Graphics g) 
        {
            //SortedList<int, MapElement> elementsInViewport = Map.getInstance().getMapElementsInCamera();
            SortedList<int, MapElement> elementsInViewport = Map.getInstance().getMapElements();
            foreach (MapElement e in elementsInViewport.Values)
            {
                e.draw(g);
            }
        }
    }
}
