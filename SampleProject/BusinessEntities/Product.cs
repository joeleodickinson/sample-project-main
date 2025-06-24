using System;

namespace BusinessEntities
{
    public class Product : IdNameObject
    {
        private decimal _price;
        private ProductTypes _type;

        public decimal Price { get; private set; }
        public ProductTypes Type { get; private set; }
        public string Description { get; private set; } // no validation needed here.

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative.");
            }
            Price = price;
        }

        public void SetType(ProductTypes type)
        {
            if (!Enum.IsDefined(typeof(ProductTypes), type))
            {
                throw new ArgumentException("Invalid product type.");
            }

            Type = type;
        }
    }
}