using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Orders.Interfaces;
using Data.Repositories.Interfaces;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrdersRepository _orderRepository;
        
        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrdersRepository orderRepository, IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }
        
        public Order CreateOrder(Guid id, User user, IEnumerable<ProductOrder> productOrders)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Order ID cannot be empty.");
            }
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }
            if (productOrders == null)
            {
                throw new ArgumentNullException(nameof(productOrders), "Product orders cannot be null.");
            }

            var order = _orderFactory.Create(id);
            _updateOrderService.UpdateOrder(order, user, productOrders);
            _orderRepository.Save(order);
            return order;
        }
    }
}