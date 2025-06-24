using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Services.Orders.Interfaces;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        public Product GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByType(ProductTypes productType)
        {
            throw new NotImplementedException();
        }
    }
}