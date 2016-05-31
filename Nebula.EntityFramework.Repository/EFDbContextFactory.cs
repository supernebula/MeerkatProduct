using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Nebula.EntityFramework.Repository
{
    public class EfDbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
    {
        private TContext _context;
        public TContext Create()
        {
            return _context ?? (_context = Activator.CreateInstance<TContext>());
        }
    }
}
