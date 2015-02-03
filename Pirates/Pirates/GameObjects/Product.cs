using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    class Product
    {
        private string mName;
        public string name { get { return mName; } }
        private int mPrice;
        public int price { set { setPrice(value); } get { return mPrice; } }
        private int minPrice;
        private int maxPrice;

        public Product(string name, int minPrice, int maxPrice)
        {
            if (name == null)
            {
                throw new NullReferenceException("Name cannot be empty");
            }
            else if (minPrice <= 0 || maxPrice <= 0)
            {
                throw new ArgumentOutOfRangeException((minPrice <= 0 ? "minPrice, " : "") + (maxPrice <= 0 ? "maxPrice" : ""), "Prices must be greater than 0");
            }
            else if (minPrice >= maxPrice)
            {
                throw new ArgumentException("minPrice must be less then maxPrice");
            }
            price = (minPrice + maxPrice) / 2;
            this.maxPrice = maxPrice;
            this.minPrice = minPrice;
            this.mName = name;
        }

        public void setPrice(int newPrice)
        {
            mPrice = Math.Min(Math.Max(newPrice, minPrice), maxPrice);
        }
    }
}
