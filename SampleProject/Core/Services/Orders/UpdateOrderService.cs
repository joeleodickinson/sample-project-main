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
    }
}