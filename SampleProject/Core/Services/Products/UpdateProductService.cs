using BusinessEntities;
using Common;
using Core.Services.Products.Interfaces;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void UpdateProduct(Product product, string name, ProductTypes productType, decimal price, string description)
        {
            product.SetName(name);
            product.SetType(productType);
            product.SetPrice(price);
            product.SetDescription(description);
        }
    }
}