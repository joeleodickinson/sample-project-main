using System;
using System.Net.Http;
using System.Web.Http;
using Core.Services.Orders;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly IGetProductService _getProductService;
        private readonly ICreateProductService _createProductService;
        
        public ProductController(IGetProductService getProductService, ICreateProductService createProductService)
        {
            _getProductService = getProductService;
            _createProductService = createProductService;
        }
        
        [Route("{id:guid}/create")]
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
    }
}