using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    abstract class AbstractMapObject
    {
        protected int level { set; get; }
        protected Location leftTop;
        protected Location rightTop;
        protected Location rightBottom;
        protected Location leftBottom;

        public AbstractMapObject(int level)
        {
            this.level = level;
        }
    }
}
