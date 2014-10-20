using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Pirates.GameObjects;
using Pirates.GameObjects.Players;

namespace Pirates.Rendering
{
    class GameEngineRenderer
    {
        private MainWindow window;
        private Thread mainGameThread;
        private bool rendering;

        private volatile List<MapElement> sceneryElements;
        private volatile List<Ship> moveableElements;
        private volatile List<NatureElement> enviromentElements;
        private volatile float testX, testY;
        private PlayersInfo playerInfo {get;set;}

        public GameEngineRenderer(MainWindow window)
        {
            this.window = window;
            mainGameThread = new Thread(StartGameLoop);
            rendering = false;
            sceneryElements = new List<MapElement>();
            moveableElements = new List<Ship>();
            enviromentElements = new List<NatureElement>();
            playerInfo = new PlayersInfo();
            testX = 0;
            testY = 0;
        }

        public void StartMainGameLoop()
        {
            rendering = true;
            mainGameThread.Start();
        }

        void StartGameLoop()
        {
            while (rendering)
            {
                //Players input refresh state
                   
                //Refreshing elements visibility and position
                foreach (MapElement e in sceneryElements)
                {
                    e.refreshVisibilityTowards(playerInfo.playersShip);
                }

                foreach (Ship sh in moveableElements)
                {
                    sh.refresh();
                    if (!(sh.Equals(playerInfo.playersShip))) 
                    {
                        sh.refreshVisibilityTowards(playerInfo.playersShip);
                    }                    
                }
                
                foreach (NatureElement n in enviromentElements)
                {
                    n.refreshVisibilityTowards(playerInfo.playersShip);
                }
                testX += 0.01f;
                testY += 0.01f;
                if (testX > 500) testX = 0;
                if (testY > 500) testY = 0;
            }
        }

        public void StopMainGameLoop()
        {
            rendering = false;
            mainGameThread.Abort();
        }

        public void invalidateElements(Graphics g)
        {
            foreach (MapElement e in sceneryElements)
            {
                e.draw(g);
            }

            foreach (Ship sh in moveableElements)
            {
                sh.draw(g);
            }

            foreach (NatureElement n in enviromentElements)
            {
                n.draw(g);
            }
            g.DrawEllipse(new Pen(Color.CadetBlue), testX, testY, 10, 10);
        }
    }
}
