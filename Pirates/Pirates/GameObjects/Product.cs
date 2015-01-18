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
        private double mPrice;
        public double price { set { setPrice(value); } get { return mPrice; } }
        private double minPrice;
        private double maxPrice;

        public Product(string name, double minPrice, double maxPrice)
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

        private void setPrice(double newPrice)
        {
            mPrice = Math.Min(Math.Max(newPrice, minPrice), maxPrice);
        }
    }
}
