using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private readonly Dictionary<Guid, ProductOrder> _productOrders = new Dictionary<Guid, ProductOrder>();

        public DateTime OrderDate { get; private set; }

        public User User { get; private set; }

        public IReadOnlyDictionary<Guid, ProductOrder> ProductOrders => _productOrders;
        
        public void SetOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
        }
        
        public void SetUser(User user)
        {
            User = user ?? throw new ArgumentNullException("User cannot be null.");
        }
        
        public void AddProductOrder(ProductOrder productOrder)
        {
            if (productOrder == null)
            {
                throw new ArgumentNullException("Product order cannot be null.");
            }

            if (_productOrders.ContainsKey(productOrder.Product.Id))
            {
                // If the product order already exists, update the quantity
                _productOrders[productOrder.Product.Id].SetQuantity(productOrder.Quantity);
            }

            _productOrders[productOrder.Product.Id] = productOrder;
        }
        
        public void RemoveProductOrder(ProductOrder productOrder)
        {
            if (!_productOrders.Remove(productOrder.Product.Id))
            {
                throw new KeyNotFoundException("Product order not found in the order.");
            }
        }
        
        public void UpdateQuantity(Guid productId, int quantity)
        {
            if (!_productOrders.TryGetValue(productId, out var currProductOrder))
            {
                throw new KeyNotFoundException("Product order not found in the order.");
            }

            currProductOrder.SetQuantity(quantity);
        }
        
        public decimal GetTotalPrice()
        {
            return _productOrders.Values.Sum(productOrder => productOrder.TotalPrice);
        }
    }
}