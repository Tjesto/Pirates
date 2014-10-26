using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    class Location
    {
        public float latitude { set; get; }

        public float longitude { set; get; }        

        public Location(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public bool isInRect(float left, float top, float right, float bottom)
        {
            if ((longitude > left && longitude < right) && (latitude > top && latitude < bottom)) 
            {
                return true;
            }
            return false;
        }

    }
}
