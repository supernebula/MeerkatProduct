﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using Dapper;
using Evol.Common;

namespace Evol.Dapper.Repository
{
    public class BasicDapperRepository<T, TDbContext> : IDisposable where TDbContext : DapperDbContext, new() where T : class, IPrimaryKey
    {


        public BasicDapperRepository()
        {
        }

        public BasicDapperRepository(IDbConnectionFactory<TDbContext> dbConnectionFactory)
        {
            DbContextFactory = dbConnectionFactory;
        }

        [Dependency]
        public IDbConnectionFactory<TDbContext> DbContextFactory { get; set; }

        public TDbContext DbContext => DbContextFactory.Create();

        public IDbConnection DbConnection => DbContext.DbConnection;

        public int Insert(string sql, T item)
        {
            return DbConnection.Execute(sql, item);
        }

        public int InsertRange(string sql, T[] items)
        {
            return DbConnection.Execute(sql, items);
        }

        public int Delete(string sql, object param)
        {
            return DbConnection.Execute(sql, param);
        }

        public T Find(string sql, object param)
        {
            return DbConnection.Query<T>(sql, param).FirstOrDefault();
        }

        public IEnumerable<T> Query(string sql, object param = null)
        {
            return DbConnection.Query<T>(sql, param);
        }



        public int Update(string sql, object param)
        {
            return DbConnection.Execute(sql, param);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
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
            DbConnection.Close();
            DbConnection.Dispose();
        }
    }
}
