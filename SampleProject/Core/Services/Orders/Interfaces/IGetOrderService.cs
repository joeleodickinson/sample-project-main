using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders.Interfaces
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);
        IEnumerable<Order> GetAllOrders(Guid? userId = null);
    }
}