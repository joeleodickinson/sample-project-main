using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Services.Orders.Interfaces;
using Data.Repositories.Interfaces;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;
        
        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProduct(Guid id)
        {
            var product = _productRepository.Get(id);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public IEnumerable<Product> GetProductsByType(ProductTypes productType)
        {
            return _productRepository.GetProductsByType(productType);
        }
    }
}