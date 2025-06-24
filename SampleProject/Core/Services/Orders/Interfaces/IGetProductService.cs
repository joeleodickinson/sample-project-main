using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IGetProductService
    {
        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product with the specified ID.</returns>
        Product GetProduct(Guid id);

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A collection of all products.</returns>
        IEnumerable<Product> GetAllProducts();
        
        /// <summary>
        /// Retrieves products filtered by the specified product type.
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        IEnumerable<Product> GetProductsByType(ProductTypes productType);
    }
}