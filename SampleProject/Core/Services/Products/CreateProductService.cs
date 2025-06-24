using System;
using BusinessEntities;
using Common;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        public Product CreateProduct(Guid id, string name, ProductTypes productType, decimal price, string descrption)
        {
            throw new NotImplementedException();
        }
    }
}