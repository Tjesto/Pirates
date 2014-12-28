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
            playersShip = new Slup();
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
    }
}
