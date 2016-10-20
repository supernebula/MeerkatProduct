using Evol.EntityFramework.Repository;
using Evol.FirstEC.Domain.Models.Entities;
using Evol.FirstEC.Domain.Repositories;

namespace Evol.FirstEC.Data.Repositories
{
    public class InStockRepository : BasicEntityFrameworkRepository<InStock, FirstEcDbContext>, IInStockRepository
    {
    }

}