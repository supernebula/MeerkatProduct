using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.EntityFramework.Repository
{
    public interface IDbContextFactory
    {
        TDbContext Create<TDbContext>() where TDbContext : NamedDbContext;
    }
}
