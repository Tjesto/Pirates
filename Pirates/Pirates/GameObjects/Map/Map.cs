using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.Rendering;

namespace Pirates.GameObjects.Map
{

    enum CollisionType { LEFT, RIGHT, TOP, BOTTOM, NONE };

    interface OnMapElementAddedListener
    {
        void onElementAdded(MapElement e);
    }

    class Map : OnMapElementAddedListener
    {        
        protected static Map instance;

        public bool forcePause { set; get; }

        public bool isInPort { set; get; }

        public bool portDecided { set; get; }

        public int collisionPortId { set; get; }

        protected CollisionType collisionType;

        protected float currentAskAngle { set; get; }

        protected Dictionary<int, List<MapElement>> objectsToRender = new Dictionary<int,List<MapElement>>();
        private int LAND_DAMAGE_COLLISION = 5;

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
            currentAskAngle = -1;
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

        public SortedList<int, MapElement> getMapElements()
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
                        elementsInCamera.Add(i++, e);                     
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

        public bool isCollisionDetected(Players.PlayersInfo player) {            
            //foreach (int level in objectsToRender.Keys)
            //{
            //    List<MapElement> elements = new List<MapElement>();
            //    if (objectsToRender.TryGetValue(level, out elements))
            //    {                    
            //        foreach (MapElement e in elements)
            //        {
            //            if (checkForCollision(e, playerShip.getLocation()))
            //            {
            //                Log.i("ms", e.getLocation().right + " x " + e.getLocation().left);
            //                return true;
            //            }
            //        }
            //    }
            //}
            collisionType = CollisionType.NONE;
            int[] tile = player.getCurrentTile();
            if (tile[0] == 0)
            {
                collisionType = CollisionType.LEFT;
            }
            else if (tile[0] == 159)
            {
                collisionType = CollisionType.RIGHT;
            }

            if (tile[1] == 0)
            {
                collisionType = collisionType == CollisionType.NONE ? CollisionType.TOP : collisionType;
            }
            else if (tile[1] == 119)
            {
                collisionType = collisionType == CollisionType.NONE ? CollisionType.BOTTOM : collisionType;
            }
            Log.d("Collision", collisionType.ToString());
            if (collisionType != CollisionType.NONE)
            {
                return true;
            }
            int collisionPortIdVal;
            //if (MapBoard.getInstance().isBlocked(tile[0], tile[1]))
            {
                if ((MapBoard.getInstance().isBlocked(tile[0] - 1, tile[1], out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] - 1, tile[1] - 1, out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] - 1, tile[1] + 1, out collisionPortIdVal)) && (Utils.checkAngle(player.playersAngle, 00, 60) ||  Utils.checkAngle(player.playersAngle, 300, 359)))
                {
                    collisionType = CollisionType.TOP;                    
                }
                else if ((MapBoard.getInstance().isBlocked(tile[0] + 1, tile[1], out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] + 1, tile[1] - 1, out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] + 1, tile[1] + 1, out collisionPortIdVal)) && Utils.checkAngle(player.playersAngle, 120, 240))
                {
                    collisionType = CollisionType.BOTTOM;
                }
                else if ((MapBoard.getInstance().isBlocked(tile[0], tile[1] - 1, out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] - 1, tile[1] - 1, out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] + 1, tile[1] - 1, out collisionPortIdVal)) && Utils.checkAngle(player.playersAngle, 210, 330))
                {
                    collisionType = CollisionType.LEFT;
                }
                else if ((MapBoard.getInstance().isBlocked(tile[0], tile[1] + 1, out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] - 1, tile[1] + 1, out collisionPortIdVal) || MapBoard.getInstance().isBlocked(tile[0] + 1, tile[1] + 1, out collisionPortIdVal)) && Utils.checkAngle(player.playersAngle, 30, 150))
                {
                    collisionType = CollisionType.RIGHT;
                }    
                collisionPortId = collisionPortIdVal;
            }
            if (MapBoard.getInstance().canDock)
            {
                forcePause = true;
                isCorrectPort = collisionPortId == WorldInfo.getInfo().randomizedPort;
            }
            else if (collisionType != CollisionType.NONE)
            {
                player.playersShip.damages += LAND_DAMAGE_COLLISION;
            }

            return collisionType != CollisionType.NONE;
        }

        private bool checkAngle(float playersAngle)
        {
            if (currentAskAngle < 0)
            {
                return true;
            }

            if (currentAskAngle > 270 && playersAngle < 90)
            {
                return 360 - currentAskAngle + playersAngle > 90;
            }

            return currentAskAngle - playersAngle > 90;
        }

        private bool checkForCollision(MapElement e, Location playersLocation)
        {
            

            float elementTop = e.getLocation().top;
            float elementLeft = e.getLocation().left;
            float elementBottom = e.getLocation().bottom;
            float elementRight = e.getLocation().right;
            float playerTop = playersLocation.top; 
            float playerLeft = playersLocation.left;
            float playerRight = playersLocation.right;
            float playerBottom = playersLocation.bottom;
            
            if (e is MapBoard)
            {                
                return !Location.isIn(e.getLocation(), playersLocation, out collisionType);
            }


            return !Location.isOutOf(e.getLocation(), playersLocation, out collisionType);
        }

        internal float[] getCollisionRosolution()
        {            
            switch (collisionType)
            {
                case CollisionType.LEFT:
                    return new float[] { 1, 0 };
                    break;
                case CollisionType.RIGHT:
                    return new float[] { -1, 0 };
                    break;
                case CollisionType.TOP:
                    return new float[] { 0, -1 };
                    break;
                case CollisionType.BOTTOM:
                    return new float[] { 0, 1 };
                    break;
                case CollisionType.NONE:
                    break;
                default:
                    break;
            }
            return null;
        }

        internal void saveCurrentAskAngle(float angle)
        {
            currentAskAngle = angle;
        }

        public bool isCorrectPort { get; set; }
    }
}
