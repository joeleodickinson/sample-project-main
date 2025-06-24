using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductTypes Type { get; set; }
        public decimal Price { get; set; }
    }
    
    public static class ProductModelExtensions
    {
        public static bool Validate(this ProductModel model, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(model.Name))
            {
                errorMessage = "Product name is required.";
                return false;
            }

            if (model.Price <= 0)
            {
                errorMessage = "Product price must be greater than zero.";
                return false;
            }

            return true;
        }
    }
}