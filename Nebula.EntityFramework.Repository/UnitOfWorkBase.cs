using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.Practices.ObjectBuilder2;
using Nebula.Common.Repository;

namespace Nebula.EntityFramework.Repository
{
    public abstract class UnitOfWorkBase : IUnitOfWork, IActiveUnitOfWork
    {
        public bool IsDisposed { get; protected set; }

        public bool IsCommited { get; protected set; }

        public Dictionary<string, DbContextTransaction> Transactions { get; }

        public Dictionary<string, NamedDbContext> ActiveDbContexts { get; }

        protected IUnitOfWorkOptions UnitOfWorkOptions { get; set; }

        protected UnitOfWorkBase()
        {
            ActiveDbContexts = new Dictionary<string, NamedDbContext>();
            Transactions = new Dictionary<string, DbContextTransaction>();
        }

        public virtual void BeginTransaction(IUnitOfWorkOptions unitOfWorkOptions)
        {
            if (unitOfWorkOptions.IsolationLevel == null)
                unitOfWorkOptions.IsolationLevel = System.Data.IsolationLevel.ReadCommitted;

            UnitOfWorkOptions = unitOfWorkOptions;
            if (UnitOfWorkOptions.IsolationLevel != null)
            {
                foreach (var context in ActiveDbContexts.Values)
                {
                    var transaction = context.Database.BeginTransaction(UnitOfWorkOptions.IsolationLevel.Value);
                    Transactions.Add(context.Name, transaction);
                }
            }
        }

        public virtual void Commit()
        {
            try
            {
                foreach (var context in ActiveDbContexts.Values)
                {
                    context.SaveChanges();
                    DbContextTransaction tran;
                    if (Transactions.TryGetValue(context.Name, out tran))
                        tran.Commit();
                }
                IsCommited = true;
            }
            catch (Exception ex)
            {
                //logger.Error(ex, "UnitOfWork Commit Error");
                foreach (var tran in Transactions.Values)
                {
                    tran.Rollback();
                }

            }
        }

        public virtual void Dispose()
        {
            ActiveDbContexts.Values.ForEach(c => c.Dispose());
            Transactions.Values.ForEach(t => t.Dispose());
        }

        public virtual void RollBack()
        {
            Transactions.Values.ForEach(t => t.Rollback());
        }

        public virtual void AddDbContext(string name, NamedDbContext dbContext)
        {
            ActiveDbContexts.Add(name, dbContext);
        }
    }
}
