using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.EntityFramework.Repository;
using Nebula.FirstEC.Domain;
using Nebula.FirstEC.Domain.Models.AggregateRoots;

namespace Nebula.FirstEC.Data.Repositories
{
    public class ProductRepository : BasicEntityFrameworkRepository<Product, NebulaFirstEcDbContext>, IProductRepository
    {
    }
}
