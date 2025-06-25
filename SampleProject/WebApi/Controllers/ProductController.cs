using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Core.Services.Orders;
using Core.Services.Orders.Interfaces;
using Core.Services.Products.Interfaces;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly IGetProductService _getProductService;
        private readonly ICreateProductService _createProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IDeleteProductService _deleteProductService;
        
        public ProductController(IGetProductService getProductService,
                                 IUpdateProductService updateProductService,
                                 IDeleteProductService deleteProductService,
                                ICreateProductService createProductService)
        {
            _getProductService = getProductService;
            _createProductService = createProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
        }
        
        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            if (_getProductService.GetProduct(productId) != null)
            {
                return AlreadyExists();
            }

            if (!model.Validate(out var errorMessage))
            {
                return InvalidRequest(errorMessage);
            }

            var product = _createProductService.CreateProduct(productId, model.Name, model.Type, model.Price, model.Description);
            return Found(new ProductData(product));
        }
        
        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            return Found(new ProductData(product));
        }
        
        [Route("all")]
        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            var products = _getProductService.GetAllProducts()
                .Select(p => new ProductData(p)).ToList();
            return Found(products);
        }
        
        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteUser(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            if (product is null)
            {
                return DoesNotExist();
            }
            _deleteProductService.Delete(product);
            return Found();
        }
    }
}