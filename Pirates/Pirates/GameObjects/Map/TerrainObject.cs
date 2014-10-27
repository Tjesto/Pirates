using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    class TerrainObject : AbstractMapObject, MapElement
    {
        public TerrainObject(int level) : base(level)
        {
            //TODO: initialize on object
        }

        public void draw(Graphics g)
        {
            //TODO:implement drawing the element
        }

        public void refreshVisibilityTowards(Ship ship)
        {
            //TODO: implement this
        }

        public int getLevel()
        {
            return level;
        }

        public Location getLocation()
        {
            return location;            
        }

    }
}
