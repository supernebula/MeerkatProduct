using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.MongoDB.Repository
{
    public class DefaultMongoDbContextFactory : IMongoDbContextFactory
    {
        private NamedMongoDbContext _dbContext;

        public TDbContext Get<TDbContext>() where TDbContext : NamedMongoDbContext, new()
        { 
            if(_dbContext == null)
                _dbContext = new TDbContext();
            return (TDbContext)_dbContext;
        }
    }
}
