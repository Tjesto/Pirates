using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.GameObjects.Map;
using Pirates.GameObjects.Ships;

namespace Pirates.GameObjects.Players
{
    class PlayersInfo
    {
        public Ship playersShip
        {
            set;
            get;
        }

        public PlayersInfo()
        {
            //restore state
            playersShip = new Slup();
            ((AbstractShip) playersShip).changeLocationToCenter();
        }
    }
}
