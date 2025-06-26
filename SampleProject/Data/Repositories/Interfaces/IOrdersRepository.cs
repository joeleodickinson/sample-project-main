using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories.Interfaces
{
    public interface IOrdersRepository : IRepository<Order>
    {
        IEnumerable<Order> GetAllOrders();
        
        IEnumerable<Order> GetOrdersByUser(Guid userId);
        void DeleteAll();
    }
}