using System.Linq.Expressions;

namespace LPGManager.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        void Delete(object entity);
        void Update(T entity);
        Task<T> GetById(long id);
        T Insert(T obj);
        void Save();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
