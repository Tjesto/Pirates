using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    class Chest
    {
        private const int MAX_CAPACITY = 20;
        private Pair<Product, int> content;
        
        public Chest(Product p)
        {
            content = Pair<Product, int>.createPairOf(p, 0);
        }

        /**
         * Adds elements to current chest, returns 0 or number of elements to add to another chest
         * 
         */
        public int addElements(int count)
        {
            int availableStorage = MAX_CAPACITY - content.second;
            if (availableStorage >= count)
            {
                content.second += count;
            }
            else
            {
                content.second = MAX_CAPACITY;
            }
            return Math.Max(count - availableStorage, 0);
        }

        /**
         * Removes elements from current chest, returns 0 or number of elements to remove from another chest
         * 
         */
        public int removeElements(int count)
        {
            int availableElements = content.second;
            if (availableElements <= count)
            {
                content.second -= count;
            }
            else
            {
                content.second = 0;
            }
            return Math.Max(count - availableElements, 0);
        }
    }
}
