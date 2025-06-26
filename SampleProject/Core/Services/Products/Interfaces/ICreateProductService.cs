using System;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateProductService
    {
        Product CreateProduct(Guid id, string name, ProductTypes productType, decimal price, string descrption);
    }
}