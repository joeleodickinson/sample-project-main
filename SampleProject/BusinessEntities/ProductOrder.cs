using System;

namespace BusinessEntities
{
    public class ProductOrder : IdObject
    {
        private int _quantity;
        private Product _product;
        
        public Product Product { get; private set; }
        public int Quantity { get; private set; } = 1;
        public decimal TotalPrice => Product.Price * Quantity;
        
        public void SetProduct(Product product)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
            }
            _quantity = quantity;
        }
    }
}