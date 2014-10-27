using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    interface Ship : MapElement
    {
        void refresh();
        void move(int x, int y);
        bool isCollisionWith(Ship ship);        
    }
}
