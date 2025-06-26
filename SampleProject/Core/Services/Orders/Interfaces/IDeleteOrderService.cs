using BusinessEntities;

namespace Core.Services.Orders.Interfaces
{
    public interface IDeleteOrderService
    {
        void DeleteOrder(Order order);
        void DeleteAllOrders();
    }
}