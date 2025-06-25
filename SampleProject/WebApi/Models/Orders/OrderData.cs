using System;
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
            
            
        }

        public UserData User { get; set; }
        public ProductData[] Products { get; set; } // Array of ProductData
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}