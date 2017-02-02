using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.MongoDB.Repository
{
    public class DefaultMongoDBContextFactory : IMongoDBContextFactory
    {

        public TDbContext Get<TDbContext>() where TDbContext : NamedMongoDBContext
        {
            throw new NotImplementedException();
        }
    }
}
