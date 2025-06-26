using System;
using System.Linq;
using BusinessEntities;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            User = new UserData(order.User);
            OrderDate = order.OrderDate;
            ProductOrders = order.ProductOrders
                .Select(po => 
                    new ProductOrderData(new ProductData(po.Value.Product), po.Value.Quantity)).ToArray();
            TotalPrice = order.GetTotalPrice();
        }

        public UserData User { get; set; }
        public ProductOrderData[] ProductOrders { get; set; } // Array of ProductData
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}