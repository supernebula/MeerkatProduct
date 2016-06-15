using Microsoft.Practices.Unity;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Nebula.Common.Repository;

namespace Nebula.EntityFramework.Repository
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private DbContext _context;
        private DbContextTransaction _transaction;

        private bool _isCommited;
        public bool IsCommited => _isCommited;

        [Dependency]
        public IDbContextFactory<TDbContext> DbContextFactory { get; set; } 

        private DbContext Context
        {
            get
            {
                return _context = _context ?? DbContextFactory.Create();
            }
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }


        public void Commit()
        {
            try
            {
                if (_transaction == null)
                    throw new NullReferenceException(nameof(_transaction));
                _context.SaveChanges();
                _transaction.Commit();
                _isCommited = true;
            }
            catch (Exception)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _context.Dispose();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}
