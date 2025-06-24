using System;
using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Price = product.Price;
            Name = product.Name;
            ProductType = new EnumData(product.Type);
            Description = product.Description;
        }
        
        public decimal Price { get; set; }
        public string Name { get; set; }
        public EnumData ProductType { get; set; }
        public string Description { get; set; }
    }
}