using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    enum MapElementCorner { LEFT_TOP, RIGHT_TOP, RIGHT_BOTTOM, LEFT_BOTTOM }
    interface MapElement
    {
        void draw(Graphics g);
        void refreshVisibilityTowards(Ship ship);
        int getLevel();
        Location getLocation(MapElementCorner corner);
    }
}
