using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.GameObjects.Map;
using Pirates.GameObjects.Ships;

namespace Pirates.GameObjects.Players
{
    enum PlayerInfoAngle { RIGHT, LEFT }

    class PlayersInfo
    {
        private int[] currentTile;
        public AbstractShip playersShip
        {
            set;
            get;
        }
        
        public float playersAngle {set;get;}

        public PlayersInfo()
        {
            //restore state
            crewNumbers = 5;
            money = 10;
            food = 450;
            playersShip = new Slup();
            playersShip.damages = 0;
            ((AbstractShip) playersShip).changeLocationToCenter();
        }

        public void updateAngle(PlayerInfoAngle angle)
        {
            playersAngle += (angle == PlayerInfoAngle.RIGHT ? 1 : -1)*playersShip.TURN_VALUE;
            if (playersAngle < 0)
            {
                playersAngle = 360 + playersAngle;
            }

            if (playersAngle >= 360)
            {
                playersAngle = playersAngle - 360;
            }
        }

        public float[] move() {

            float[] move = new float[2];
            double angle = Utils.DegreeToRadian(playersAngle);
            move[0] = (float) (Math.Sin(angle) * playersShip.velocity);
            move[1] = (float)(Math.Cos(angle) * playersShip.velocity);
            
            return move;
        }

        public int[] getCurrentTile()
        {
            currentTile = new int[]{(int) ((((playersShip.getLocation().left + playersShip.getLocation().right) /2 ) - MapBoard.getInstance().getLocation().left)/10),
                                    (int) ((((playersShip.getLocation().top + playersShip.getLocation().bottom) /2 ) - MapBoard.getInstance().getLocation().top)/10)};
            return currentTile;
        }

        internal void setAngleToGoOut()
        {
            playersAngle += 180;
            if (playersAngle < 0)
            {
                playersAngle = 360 + playersAngle;
            }

            if (playersAngle >= 360)
            {
                playersAngle = playersAngle - 360;
            }
        }

        public int crewNumbers { get; set; }

        public int money { get; set; }

        public int food { get; set; }

        public int foodForDays()
        {
            return food / 34;
        }

        public int foodForMonths()
        {
            return foodForDays() / 30;
        }

        internal string getFoodString()
        {
            if (foodForDays() > 30)
            {
                return foodForMonths() + " mies.";
            }
            else if (foodForDays() >= 0)
            {
                return foodForDays() + " dni";
            }
            else
            {
                return "0 dni";
            }
        }

        internal void newDay()
        {
            food -= 34;
        }
    }
}
