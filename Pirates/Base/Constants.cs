using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public enum FieldType 
    { 
        WATER = 0,
        LAND = 1,
        CITY = 2        
    }

    public class MapFieldsType
    {
        public FieldType type { set; get; }
        public string name { set; get; }

        public MapFieldsType(int type, string name) : this((FieldType) type, name)
        {
            //empty;
        }

        public MapFieldsType(FieldType type, string name)
        {
            this.type = type;
            this.name = name;
        }
        
    }
}
