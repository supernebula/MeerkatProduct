using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nebula.Common;

namespace Nebula.EntityFramework.Repository
{
    /// <summary>
    /// 基础仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class BasicEntityFrameworkRepository<T, TDbContext> where TDbContext : DbContext, new() where T : class, IPrimaryKey
    {

        protected BasicEntityFrameworkRepository()
        { 
        }

        protected BasicEntityFrameworkRepository(IDbContextFactory<TDbContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

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

        [Dependency]
        public IEfDbContextSingleFactory DbContextSingleFactory { get; set; }

        private DbContext Context2
        {
            get
            {
                return _context = _context ?? DbContextSingleFactory.Current<TDbContext>();
            }
        }


        public DbSet<T> DbSet => Context.Set<T>();

        public Database Database => Context.Database;

        private void Save()
        {
            Context.SaveChanges();
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

        public T Find(Guid id)
        {
            return DbSet.Find(id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public async Task<T> FindAsync(Guid id)
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
    }
}
