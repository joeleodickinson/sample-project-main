using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders.Interfaces
{
    public interface IUpdateOrderService
    {
        void UpdateOrder(Order order, User user, IEnumerable<ProductOrder> productOrders);
    }
}