using System;
using System.Collections.Generic;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid UserId { get; set; }
        public Dictionary<Guid, int> Products { get; set; } // ProductId and Quantity
    }
    
    public static class OrderModelExtensions
    {
        public static bool Validate(this OrderModel model, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (model.UserId == Guid.Empty)
            {
                errorMessage = "UserId is required.";
                return false;
            }

            if (model.Products == null || model.Products.Count == 0)
            {
                errorMessage = "Products must not be null or empty.";
                return false;
            }

            foreach (var product in model.Products)
            {
                if (product.Key == Guid.Empty)
                {
                    errorMessage = $"ProductId {product.Key} is invalid.";
                    return false; 
                }

                if (product.Value <= 0)
                {
                    errorMessage = $"Quantity for ProductId {product.Key} must be greater than zero.";
                    return false; 
                }
            }

            return true;
        }
    }
}