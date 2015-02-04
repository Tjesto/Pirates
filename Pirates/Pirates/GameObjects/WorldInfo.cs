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

        private long daysSinceGameStarted;

        private volatile Dictionary<WorldInfo.Keys, Object> events;

        private static volatile WorldInfo instance;

        private List<Product> products;

        public Random r;

        private WorldInfo()
        {
            daysSinceGameStarted = 1;
            r = new Random();
            products = new List<Product>();
            products.Add(new Product("Rum", 5, 43));
            products.Add(new Product("Żywność", 1, 8));
            products.Add(new Product("Amunicja", 20, 120));
            products.Add(new Product("Tkaniny", 4, 53));
            products.Add(new Product("Przyprawy", 3, 38));
            products.Add(new Product("Papier", 5, 14));
            products.Add(new Product("Deski", 6, 114));
            updatePrices();
        }

        public static WorldInfo getInfo()
        {
            if (instance == null)
            {
                instance = new WorldInfo();
            }
            return instance;
        }

        private void updatePrices()
        {
            foreach (Product p in products)
            {
                p.setPrice(r.Next());
            }
        }

        public void updateDaily()
        {
            updatePrices();        
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
            return products;
        }

        internal Product getProductWithName(string p)
        {
            foreach (Product prod in products) {
                if (p.Equals(prod.name))
                {
                    return prod;
                }
            }
            return null;
        }

        public void randomizePort()
        {
            randomizedPort = r.Next(101, 107);
        }        

        public int randomizedPort { get; set; }
    }
}
