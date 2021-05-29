using System.Collections.Generic;

namespace Models.DAO
{
    public interface IRepository<T>
    {
        IEnumerable<T> ListAllPaging(int page, int pageSize);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}