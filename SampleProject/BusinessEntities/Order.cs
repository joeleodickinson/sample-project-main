using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private DateTime _orderDate;
        private User _user;
        private Dictionary<Guid, ProductOrder> _productOrders = new Dictionary<Guid, ProductOrder>();

        public DateTime OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }
        
        public User User
        {
            get => _user;
            private set => _user = value;
        }
        
        public void SetOrderDate(DateTime orderDate)
        {
            _orderDate = orderDate;
        }
        
        public void SetUser(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }
        
        public void AddProductOrder(ProductOrder productOrder)
        {
            if (productOrder == null)
            {
                throw new ArgumentNullException(nameof(productOrder), "Product order cannot be null.");
            }

            if (_productOrders.ContainsKey(productOrder.Id))
            {
                throw new InvalidOperationException("Product order already exists in the order.");
            }

            _productOrders[productOrder.Id] = productOrder;
        }
        
        public void RemoveProductOrder(Guid productOrderId)
        {
            if (!_productOrders.Remove(productOrderId))
            {
                throw new KeyNotFoundException("Product order not found in the order.");
            }
        }
        
        public void UpdateQuantity(Guid productOrderId, int quantity)
        {
            if (!_productOrders.TryGetValue(productOrderId, out var productOrder))
            {
                throw new KeyNotFoundException("Product order not found in the order.");
            }

            productOrder.SetQuantity(quantity);
        }
        
        public decimal GetTotalPrice()
        {
            return _productOrders.Values.Sum(productOrder => productOrder.TotalPrice);
        }
    }
}