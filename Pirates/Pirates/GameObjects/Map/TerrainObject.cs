﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    class TerrainObject : AbstractMapObject, MapElement
    {
        private string nameImpl;
        public string name { get { return nameImpl; } }

        public TerrainObject(int level)
            : base(level)
        {
            //empty
        }

        public TerrainObject(int level, Location location, string name) : base(level)
        {
            this.location = location;
            this.nameImpl = name;
        }

        public void draw(Graphics g)
        {
            Pen pen = new Pen(Utils.getLandColor(), 1);
            g.DrawRectangle(pen, location.left, location.top, 10, 10);
            g.FillRectangle(Brushes.DarkGoldenrod, location.left, location.top, 10, 10);
        }

        public void refreshVisibilityTowards(float[] moveLocation)
        {
            location.move(moveLocation[0], moveLocation[1]);
        }

        public int getLevel()
        {
            return level;
        }

        public Location getLocation()
        {
            return location;            
        }

        public override string ToString()
        {
            return nameImpl + " is in [" + location + "]";
        }

    }
}
