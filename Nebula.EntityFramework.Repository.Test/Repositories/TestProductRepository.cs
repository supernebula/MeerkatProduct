using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.EntityFramework.Repository;
using Nebula.EntityFramework.Repository.Test.Entities;

namespace Nebula.EntityFramework.Repository.Test.Repositories
{
    public class TestProductRepository : BasicEntityFrameworkRepository<TestProduct, TestEcDbContext>
    {
    }
}
