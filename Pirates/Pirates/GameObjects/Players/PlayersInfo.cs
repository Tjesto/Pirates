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
        }
    }
}
