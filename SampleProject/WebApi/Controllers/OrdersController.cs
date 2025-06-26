using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Orders.Interfaces;
using Core.Services.Users.Interfaces;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : BaseApiController
    {
        private readonly IGetOrderService _getOrderService;
        private readonly IGetProductService _getProductService;
        private readonly IGetUserService _getUserService;
        private readonly ICreateOrderService _createOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IDeleteOrderService _deleteOrderService;

        public OrdersController(IGetOrderService getOrderService,
                                IGetProductService getProductService,
                                IGetUserService getUserService,
                                ICreateOrderService createOrderService,
                                IUpdateOrderService updateOrderService,
                                IDeleteOrderService deleteOrderService)
        {
            _getOrderService = getOrderService;
            _getProductService = getProductService;
            _getUserService = getUserService;
            _createOrderService = createOrderService;
            _updateOrderService = updateOrderService;
            _deleteOrderService = deleteOrderService;
        }
        
        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (_getOrderService.GetOrder(orderId) != null)
            {
                return AlreadyExists();
            }

            if (!model.Validate(out var errorMessage))
            {
                return InvalidRequest(errorMessage);
            }
            
            // Note: I was not sure if it would be better to store the full order moder or just the userId, ProductIds,
            // and other relevant data and construct the full order object only when requested, this would save storage.
            // However, since we are using document storage, I figured using multiple calls on a get request would
            // impede performance, therefore I decided to store the full order object.
            var user = _getUserService.GetUser(model.UserId);
            var productOrders = new List<ProductOrder>();
            foreach (var product in model.Products)
            {
                var productEntity = _getProductService.GetProduct(product.Key);
                var productOrder = new ProductOrder();
                productOrder.SetProduct(productEntity);
                productOrder.SetQuantity(product.Value);
                productOrders.Add(productOrder);
            }
            var order = _createOrderService.CreateOrder(orderId, user, productOrders);
            return Found(new OrderData(order));
        }
        
        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            
            if (order is null)
            {
                return DoesNotExist();
            }
            
            return Found(new OrderData(order));
        }
        
        // Note: I am unsure if this belongs here or in the UserController, but since it is an order related operation,
        // I decided to keep it here for now, though the use of the userId in the route might be confusing.
        [Route("{userId:guid}/list")]
        [HttpGet]
        public HttpResponseMessage GetAllOrdersByUser(Guid userId)
        {
            var user = _getUserService.GetUser(userId);
            if (user is null)
            {
                return DoesNotExist();
            }
            
            var orders = _getOrderService.GetOrdersByUser(userId);
            var orderDataList = new List<OrderData>();
            foreach (var order in orders)
            {
                orderDataList.Add(new OrderData(order));
            }
            return Found(orderDataList);
        }

        [Route("{orderId:guid}/update-quantity")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] ProductOrderModel model)
        {
            if (!model.Validate(out var errorMessage))
            {
                return InvalidRequest(errorMessage);
            }
            
            var order = _getOrderService.GetOrder(orderId);
            if (order is null)
            {
                return DoesNotExist();
            }
            
            // TODO: check if this works for both adding and updating
            order.ProductOrders[model.ProductId].SetQuantity(model.Quantity);
            
            _updateOrderService.UpdateOrder(order, order.User, order.ProductOrders.Values);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order is null)
            {
                return DoesNotExist();
            }

            _deleteOrderService.DeleteOrder(order);
            return Found();
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage ClearOrders()
        {
            _deleteOrderService.DeleteAllOrders();
            return Found();
        }

    }
}