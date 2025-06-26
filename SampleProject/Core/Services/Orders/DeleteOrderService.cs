using System;
using BusinessEntities;
using Common;
using Core.Services.Orders.Interfaces;
using Data.Repositories.Interfaces;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService : IDeleteOrderService
    {
        private readonly IOrdersRepository _orderRepository;
        
        public DeleteOrderService(IOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public void DeleteOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }
            _orderRepository.Delete(order);
        }

        public void DeleteAllOrders()
        {
            _orderRepository.DeleteAll();
        }
    }
}