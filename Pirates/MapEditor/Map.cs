using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MapEditor
{
    class Map
    {
        public int width { set; get; }
        
        public int height { set; get; }

        public string name { set; get; }

        public Map(int width, int height, string name)
        {
            this.width = width;
            this.height = height;
            this.name = name;
            StreamWriter writer = new StreamWriter(MapEditor.Properties.Resources.path + name);
        }
    }
}
