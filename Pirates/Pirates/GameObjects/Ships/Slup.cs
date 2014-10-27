﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Ships
{
    class Slup : AbstractShip
    {
        public Slup()
        {
            texture = Properties.Resources.slup;
            cannonsCount = 1;
            type = "Slup";
            crewCount = 2;
            MAX_CREW = 15;
            TURN_VALUE = 2;
            location = new Location(0, 0, 0, 0);
        }

        public Slup(Location location) : this()
        {            
            this.location = location;
        }

    }
}