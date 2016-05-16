using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.EntityFramework.Repository;
using Nebula.FirstEC.Compoment;
using Nebula.FirstEC.Data.Repositories;

namespace Nebula.FirstEC.DataStorage.Repositories
{
    public class ProductRepository : BasicEntityFrameworkRepository<Product, NebulaFirstEcDbContext>, IProductRepository
    {
    }
}
