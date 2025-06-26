using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders.Interfaces
{
    public interface ICreateOrderService
    {
        Order CreateOrder(Guid id, User user, IEnumerable<ProductOrder> productOrders);
    }
}