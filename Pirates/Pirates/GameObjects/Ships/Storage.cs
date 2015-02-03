using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Ships
{
    class Storage
    {
        private int maxCapacityImpl;
        public int maxCapacity { get { return maxCapacityImpl; } }
        private int currentCapacity { set; get; }
        private List<Pair<Product, int>> content;

        public Storage(int maxCapacity)
        {                      
            this.maxCapacityImpl = maxCapacity;
            content = new List<Pair<Product,int>>();
        }

        public int addProducts(Product product, int count)
        {
            Pair<Product, int> p = null;
            int products = -1;
            foreach (Pair<Product, int> pair in content)
            {
                if (pair.first.name.Equals(product.name))
                {
                    p = pair;
                    products = pair.second;
                    break;
                }
            }
            
            if (products == -1)
            {
                p = Pair<Product, int>.createPairOf(product, 0);
                content.Add(p);                
            }
            int productsToAdd = maxCapacity - currentCapacity;
            p.second += Math.Min(count, productsToAdd);
            currentCapacity += Math.Min(count, productsToAdd);
            return Math.Max(count - productsToAdd, 0);
        }

        public int removeProducts(Product product, int count)
        {
            Pair<Product, int> p = null;
            int products = -1;
            foreach (Pair<Product, int> pair in content)
            {
                if (pair.first.name.Equals(product.name))
                {
                    p = pair;
                    products = pair.second;
                    break;
                }
            }

            if (products == -1)
            {
                return count;
            }
            int productsToAdd = currentCapacity;
            p.second -= Math.Min(count, productsToAdd);

            return Math.Max(count - productsToAdd, 0);
        }


        internal int getAmount(Product product)
        {
            Pair<Product, int> p = null;
            int products = -1;
            foreach (Pair<Product, int> pair in content)
            {
                if (pair.first.name.Equals(product.name))
                {
                    p = pair;
                    products = pair.second;
                    break;
                }
            }
            return Math.Max(products, 0);
        }
    }
}
