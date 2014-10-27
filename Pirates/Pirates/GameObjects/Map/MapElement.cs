using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{    
    interface MapElement
    {
        void draw(Graphics g);
        void refreshVisibilityTowards(Ship ship);
        int getLevel();
        Location getLocation();
    }
}
