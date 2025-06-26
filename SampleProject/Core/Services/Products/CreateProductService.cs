using System;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Orders;
using Core.Services.Products.Interfaces;
using Data.Repositories.Interfaces;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IUpdateProductService _updateProductService;
        private readonly IIdObjectFactory<Product> _userFactory;
        private readonly IProductRepository _productRepository;
        
        public CreateProductService(IIdObjectFactory<Product> userFactory, IProductRepository productRepository, IUpdateProductService updateProductService)
        {
            _userFactory = userFactory;
            _productRepository = productRepository;
            _updateProductService = updateProductService;
        }
        
        public Product CreateProduct(Guid id, string name, ProductTypes productType, decimal price, string descrption)
        {
            var product = _userFactory.Create(id);
            _updateProductService.UpdateProduct(product, name, productType, price, descrption);
            _productRepository.Save(product);
            return product;
        }
    }
}