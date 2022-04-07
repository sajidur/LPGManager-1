using System.Linq.Expressions;

namespace LPGManager.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        void Delete(long entity);
        void Update(T entity);
        Task<T> GetById(long id);
        Task<long> GetLastId(string table);
        long GetLastId();
        T Insert(T obj);
        void Save();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
