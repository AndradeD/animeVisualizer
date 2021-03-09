using System.Collections.Generic;

namespace Animes.Interfaces
{
    public interface IRepository<T>
    {
         List<T> ReturnAll();
         T GetByID(int id);
         void Insert(T entity);
         void Delete(int id);
         void Update(int id, T entity);
         int NextId();

    }
}