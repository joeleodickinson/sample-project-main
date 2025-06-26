using System;
using WebApi.Models.Products;

namespace WebApi.Models.Orders
{
    public class ProductOrderData
    {
        public ProductOrderData(ProductData productData, int quantity)
        {
            Product = productData;
            Quantity = quantity;
        }

        public ProductData Product { get; set; }
        public int Quantity { get; set; }
    }
}