using Nebula.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nebula.EntityFramework.Repository
{
    public class OriginalEntityFrameworkRepository<T, TDbContext> : IDisposable where TDbContext : DbContext, new() where T : class, IPrimaryKey
    {
        private TDbContext _context;
        public OriginalEntityFrameworkRepository(TDbContext context)
        {
            _context = context;
        }


        protected DbSet<T> DbSet => _context.Set<T>();

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Insert(T item)
        {
            DbSet.Add(item);
        }

        public void InsertRange(IEnumerable<T> items)
        {
            DbSet.AddRange(items);
        }

        public void Delete(T item)
        {
            DbSet.Remove(item);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Fetch(Guid id)
        {
            return DbSet.Find(id);
        }

        public T Fetch(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public async Task<T> FetchAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public IQueryable<T> Query()
        {
            return DbSet.AsQueryable();
        }

        public IEnumerable<T> Retrieve(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> RetrieveAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => DbSet.Where(predicate));
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public IPaged<T> Paged(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IPaged<T> Paged(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();


        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
