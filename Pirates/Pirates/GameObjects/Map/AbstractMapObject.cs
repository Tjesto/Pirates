using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Map
{
    abstract class AbstractMapObject
    {
        protected int level { set; get; }
        protected Location location;

        public AbstractMapObject(int level)
        {
            this.level = level;
        }
    }
}
