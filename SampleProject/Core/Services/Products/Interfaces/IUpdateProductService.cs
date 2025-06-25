using BusinessEntities;

namespace Core.Services.Products.Interfaces
{
    public interface IUpdateProductService
    {
        void UpdateProduct(Product product, string name, ProductTypes productType, decimal price, string description);
    }
}