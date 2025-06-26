using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Services.Orders.Interfaces;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void UpdateOrder(Order order, User user, IEnumerable<ProductOrder> productOrders)
        {
            order.SetUser(user);
            order.SetOrderDate(DateTime.Now);
            foreach (var productOrder in productOrders)
            {
                order.AddProductOrder(productOrder);
            }
        }
        
        public void UpdateProductQuantity(Order order, Guid productId, int quantity)
        {
            order.UpdateQuantity(productId, quantity);
        }

        public void AddProductOrder(Order order, ProductOrder productOrder)
        {
            order.AddProductOrder(productOrder);
        }

        public void RemoveProductOrder(Order order, ProductOrder productOrder)
        {
            throw new NotImplementedException();
        }
    }
}