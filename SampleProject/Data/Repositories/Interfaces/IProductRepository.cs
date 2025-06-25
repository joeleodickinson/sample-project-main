using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
        
        IEnumerable<Product> GetProductsByType(ProductTypes productType);
        void DeleteAll();
    }
}