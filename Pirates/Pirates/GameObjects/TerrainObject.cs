using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
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

        public Location getLocation(MapElementCorner corner)
        {
            Location l = null;
            switch (corner)
            {
                case MapElementCorner.LEFT_BOTTOM: l = leftBottom;
                    break;
                case MapElementCorner.LEFT_TOP: l = leftTop;
                    break;
                case MapElementCorner.RIGHT_BOTTOM: l = rightBottom;
                    break;
                case MapElementCorner.RIGHT_TOP: l = rightTop;
                    break;
            }

            return l;
        }

    }
}
