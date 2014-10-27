using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Ships
{
    class Slup : AbstractShip
    {
        public Slup() : base("slup.png")
        {
            cannonsCount = 1;
            type = "Slup";
            crewCount = 2;
            MAX_CREW = 15;
            location = new Location(0, 0, 0, 0);
        }

        public Slup(Location location)
            : base("slup.png")
        {
            cannonsCount = 1;
            type = "Slup";
            crewCount = 2;
            MAX_CREW = 15;
            this.location = location;
        }

    }
}
