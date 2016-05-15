using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.EntityFramework.Repository
{
    public class EFDbContextFactory<TDbContext> : IDbContextFactory<TDbContext> where TDbContext : DbContext, new()
    {
        private TDbContext _context;
        public TDbContext Create()
        {
            return _context == null ? Activator.CreateInstance<TDbContext>() : _context;
        }
    }
}
