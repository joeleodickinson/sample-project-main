using BusinessEntities;

namespace Core.Services.Users.Interfaces
{
    public interface IDeleteUserService
    {
        void Delete(User user);
        void DeleteAll();
    }
}