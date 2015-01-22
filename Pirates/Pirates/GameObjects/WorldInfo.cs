using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    class WorldInfo
    {
        public enum Keys {
            PRICES,// List<Pair<String, List<Product>>
            WARS // List<Pair<String, String>

        }

        private int daysSinceGameStarted;

        private volatile Dictionary<WorldInfo.Keys, Object> events;

        private static volatile WorldInfo instance;

        private WorldInfo()
        {
            daysSinceGameStarted = 1;
        }

        public static WorldInfo getInfo()
        {
            if (instance == null)
            {
                instance = new WorldInfo();
            }
            return instance;
        }

        public void updateDaily()
        {
            //do daily update           
            if ((++daysSinceGameStarted) % 7 == 0)
            {
                updateWeekly();
            }
            if ((daysSinceGameStarted) % 30 == 0)
            {
                updateMonthly();
            }
        }

        public void updateWeekly()
        {

        }

        public void updateMonthly()
        {

        }



        internal int getPriceOf(Product product)
        {
            return 10;
        }        

        internal int getProductAmount(Product product)
        {
            return 10000;   
        }

        internal List<Product> getProducts()
        {
            return null;
        }
    }
}
