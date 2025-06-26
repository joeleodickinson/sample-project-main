using System;

namespace WebApi.Models.Orders
{
    public class ProductOrderModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
    
    public static class ProductOrderModelExtensions
    {
        public static bool Validate(this ProductOrderModel model, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (model.ProductId == Guid.Empty)
            {
                errorMessage = "ProductId is required.";
                return false;
            }

            if (model.Quantity <= 0)
            {
                errorMessage = "Quantity must be greater than zero.";
                return false;
            }

            return true;
        }
    }
}