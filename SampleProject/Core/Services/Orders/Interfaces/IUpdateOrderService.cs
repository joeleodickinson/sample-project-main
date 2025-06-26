using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders.Interfaces
{
    public interface IUpdateOrderService
    {
        void UpdateOrder(Order order, User user, IEnumerable<ProductOrder> productOrders);

        void UpdateProductQuantity(Order order, Guid productId, int quantity);
        
        void AddProductOrder(Order order, ProductOrder productOrder);
        void RemoveProductOrder(Order order, ProductOrder productOrder);
    }
}