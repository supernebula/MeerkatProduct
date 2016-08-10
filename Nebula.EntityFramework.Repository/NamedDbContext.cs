using System.Data.Entity;
using Nebula.Common;

namespace Nebula.EntityFramework.Repository
{
    public class NamedDbContext : DbContext, INamed
    {
        public string Name { get;set; }
    }
}
