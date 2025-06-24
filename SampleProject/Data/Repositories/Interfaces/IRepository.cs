using System;
using BusinessEntities;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : IdObject
    {
        void Save(T entity);
        void Delete(T entity);
        T Get(Guid id);
    }
}