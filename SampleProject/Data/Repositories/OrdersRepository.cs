using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    // Singleton repository since it is a simple in-memory store.
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrdersRepository : IOrdersRepository
    {
        // Simulating a data store with an in-memory dictionary
        private readonly Dictionary<Guid, Order> _orders = new Dictionary<Guid, Order>();
        
        public void Save(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Order cannot be null");
            }
            
            _orders.Add(entity.Id, entity);
        }

        public void Delete(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Order cannot be null");
            }

            if (!_orders.Remove(entity.Id))
            {
                throw new KeyNotFoundException("Order not found in the repository");
            }
        }

        public Order Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid Order ID", nameof(id));
            }

            if (_orders.TryGetValue(id, out var order))
            {
                return order;
            }

            return null;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders.Values;
        }

        public IEnumerable<Order> GetOrdersByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("Invalid User ID", nameof(userId));
            }

            return _orders.Values.Where(order => order.User != null && order.User.Id == userId).ToList();
        }

        public void DeleteAll()
        {
            _orders.Clear();
        }
    }
}