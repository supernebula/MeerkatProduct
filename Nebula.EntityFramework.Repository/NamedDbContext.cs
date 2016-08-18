using System.Data.Entity;
using Nebula.Common;

namespace Nebula.EntityFramework.Repository
{
    public abstract class NamedDbContext : DbContext, INamed
    {
        protected NamedDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public string Name { get;set; }
    }
}
