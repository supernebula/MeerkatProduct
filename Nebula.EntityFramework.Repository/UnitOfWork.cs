using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Nebula.Common.Repository;

namespace Nebula.EntityFramework.Repository
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : NamedDbContext
    {
        
        private DbContextTransaction _transaction;

        private bool _isCommited;
        public bool IsCommited => _isCommited;

        private readonly DbContextProxy _dbContextProxy;

        private Dictionary<string, TDbContext> ActiveDbContexts { get; set; }

        private IUnitOfWorkOptions _unitOfWorkOptions;

        private delegate void OnDbContentCreated(TDbContext dbContext);
        private event OnDbContentCreated DbContextCreatedEvent;

        public UnitOfWork()
        {
            _dbContextProxy = new DbContextProxy();
            ActiveDbContexts = new Dictionary<string, TDbContext>();
            DbContextCreatedEvent +=
                context => ActiveDbContexts.Add(context.GetType().FullName + "#" + context.Name, context);
        }



        public IDbContextFactory<TDbContext> DbContextFactory;

        public void BeginTransaction(IUnitOfWorkOptions unitOfWorkOptions)
        {
            _unitOfWorkOptions = unitOfWorkOptions;
            if(_unitOfWorkOptions.IsolationLevel != null)
                DbContextCreatedEvent += context => context.Database.BeginTransaction(_unitOfWorkOptions.IsolationLevel.Value);

            _dbContextProxy.WaitUntilDbContextCreated(context =>
            {
                if (_unitOfWorkOptions.IsolationLevel != null)
                    _transaction = context.Database.BeginTransaction(_unitOfWorkOptions.IsolationLevel.Value);
            });
        }

        //public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        //{
        //    _dbContextProxy.WaitUntilDbContextCreated(context => _transaction = context.Database.BeginTransaction(isolationLevel));
        //}


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
