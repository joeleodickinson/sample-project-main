using BusinessEntities;

namespace Core.Services.Products.Interfaces
{
    public interface IDeleteProductService
    {
        void Delete(Product product);
        void DeleteAll();
    }
}