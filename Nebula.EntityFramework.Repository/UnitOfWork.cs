using Microsoft.Practices.Unity;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Nebula.Common.Repository;

namespace Nebula.EntityFramework.Repository
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        
        private DbContextTransaction _transaction;

        private bool _isCommited;
        public bool IsCommited => _isCommited;

        private readonly DbContextProxy _dbContextProxy;

        public UnitOfWork()
        {
            _dbContextProxy = new DbContextProxy();
        }

       

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _dbContextProxy.WaitUntilDbContextCreated(context => _transaction = context.Database.BeginTransaction(isolationLevel));
        }


        public void Commit()
        {
            try
            {
                _dbContextProxy.WaitUntilDbContextCreated(context =>
                {
                    if (_transaction == null)
                        throw new NullReferenceException(nameof(_transaction));
                    context.SaveChanges();
                    _transaction.Commit();
                    _isCommited = true;
                });

            }
            catch (Exception)
            {
                _dbContextProxy.WaitUntilDbContextCreated(context =>
                {
                    _transaction.Rollback();
                });
            }
        }

        public void Dispose()
        {
            _dbContextProxy.WaitUntilDbContextCreated(context =>
            {
                _transaction.Dispose();
                context.Dispose();
            });

        }

        public void RollBack()
        {
            _dbContextProxy.WaitUntilDbContextCreated(context =>
            {
                _transaction.Rollback();
            });
            
        }
    }
}
