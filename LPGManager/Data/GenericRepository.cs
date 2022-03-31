using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LPGManager.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppsDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository(AppsDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = table.Where(predicate);
            return query;
        }

        public async Task<T> GetById(long id)
        {
            return await table.FindAsync(id);
        }

        public T Insert(T obj)
        {
            table.Add(obj);
            return obj;
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
