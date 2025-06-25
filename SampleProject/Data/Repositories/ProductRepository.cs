using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    // Singleton repository since it is a simple in-memory store.
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : IProductRepository
    {
        // Simulating a data store with an in-memory dictionary
        private readonly Dictionary<Guid, Product> _products = new Dictionary<Guid, Product>();

        public void Save(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Product cannot be null");
            }
            
            _products.Add(entity.Id, entity);
        }

        public void Delete(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Product cannot be null");
            }

            if (!_products.Remove(entity.Id))
            {
                throw new KeyNotFoundException("Product not found in the repository");
            }
        }

        public Product Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }

            if (_products.TryGetValue(id, out var product))
            {
                return product;
            }

            return null;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products.Values;
        }

        public IEnumerable<Product> GetProductsByType(ProductTypes productType)
        {
            if (!Enum.IsDefined(typeof(ProductTypes), productType))
            {
                throw new ArgumentException("Invalid product type", nameof(productType));
            }
            
            return _products.Values.Where(x => x.Type == productType);
        }

        public void DeleteAll()
        {
            _products.Clear();
        }
    }
}