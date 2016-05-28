﻿using Nebula.EntityFramework.Repository;
using Nebula.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nebula.Common;

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

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Insert(T item)
        {
            return DbSet.Add(item);
        }

        public IEnumerable<T> InsertRange(IEnumerable<T> items)
        {
            return DbSet.AddRange(items);
        }

        public T Delete(T item)
        {
            return DbSet.Remove(item);
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

        public IPaged<T> Paged(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> order, int pageIndex, int pageSize)
        {
            var queryable = DbSet.Where(predicate).OrderBy(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            var result = new Paged<T>(queryable.ToList(), pageIndex, pageSize);
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}