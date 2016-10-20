﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Evol.Common;

namespace Evol.EntityFramework.Repository
{
    /// <summary>
    /// 基础仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class BasicEntityFrameworkRepository<T, TDbContext> where TDbContext : NamedDbContext, new() where T : class, IPrimaryKey
    {
        private TDbContext _context;

        [Dependency]
        public IDbContextFactory DbContextFactory { get; set; }

        private NamedDbContext Context
        {
            get
            {
                return _context = _context ?? DbContextFactory.Create<TDbContext>();
            }
        }

        public DbSet<T> DbSet => Context.Set<T>();

        public Database Database => Context.Database;

        protected BasicEntityFrameworkRepository()
        { 
        }

        protected BasicEntityFrameworkRepository(IDbContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
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
            var item = Find(id);
            Delete(item);
        }

        public void Save()
        {
            //wait for Context.SaveChange(),  item is being tracked object
        }

        public T Find(Guid id)
        {
            return DbSet.Find(id);
        }
        public async Task<T> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }


        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).FirstOrDefaultAsync();
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
            return await DbSet.Where(predicate).ToListAsync();
        }

        public void Update(T item)
        {
            //wait for Context.SaveChange(),  item is being tracked object
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public IPaged<T> Paged(int pageIndex, int pageSize)
        {
            var total = DbSet.Count();
            var list = DbSet.OrderBy(e => e.Id).Skip(pageIndex*(pageSize - 1)).Take(pageSize).ToList();
            var paged = new Paged<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public async Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize)
        {
            var total = await DbSet.CountAsync();
            var list = await DbSet.OrderBy(e => e.Id).Skip(pageIndex * (pageSize - 1)).Take(pageSize).ToListAsync();
            var paged = new Paged<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public IPaged<T> Paged(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            var total = DbSet.Count(predicate);
            var list = DbSet.OrderBy(e => e.Id).Skip(pageIndex * (pageSize - 1)).Take(pageSize).ToList();
            var paged = new Paged<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public async Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            var total = await DbSet.CountAsync(predicate);
            var list = await DbSet.Where(predicate).OrderBy(e => e.Id).Skip(pageIndex * (pageIndex - 1)).Take(pageSize).ToListAsync();
            var paged = new Paged<T>(list, total, pageIndex, pageSize);
            return paged;
        }
    }
}
