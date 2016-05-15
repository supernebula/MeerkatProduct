using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.EntityFramework.Repository
{
    /// <summary>
    /// 基础仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class BasicEntityFrameworkRepository<T, TDbContext> : IRepository<T> where TDbContext : DbContext, new() where T : class
    {

        private TDbContext _context;


        [Dependency]
        public IDbContextFactory<TDbContext> DbContextFactory { get; set; }

        private DbContext Context
        {
            get
            {
                return _context = _context ?? DbContextFactory.Create();
            }
        }

        public BasicEntityFrameworkRepository()
        {
        }

        protected DbSet<T> DbSet => _context.Set<T>();

        private  int Save()
        {
            return Context.SaveChanges();
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

        public T Fetch(Guid id)
        {
            return DbSet.Find(id);
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

        public IEnumerable<T> Paged(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();


        }
    }
}
