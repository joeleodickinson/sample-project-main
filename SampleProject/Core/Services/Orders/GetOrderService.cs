using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Services.Orders.Interfaces;
using Data.Repositories.Interfaces;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrdersRepository _orderRepository;
        
        public GetOrderService(IOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public Order GetOrder(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Order ID cannot be empty.");
            }
            return _orderRepository.Get(id);
        }

        public IEnumerable<Order> GetAllOrders(Guid? userId = null)
        {
            if (userId.HasValue && userId.Value == Guid.Empty)
            {
                throw new ArgumentException("Invalid User ID");
            }
            
            if (userId.HasValue)
            {
                return _orderRepository.GetOrdersByUser(userId.Value);
            }
            
            return _orderRepository.GetAllOrders();
        }
    }
}