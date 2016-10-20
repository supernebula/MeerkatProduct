using Evol.FirstEC.Domain.Repositories;
using Evol.EntityFramework.Repository;
using Evol.FirstEC.Domain.Models.AggregateRoots;

namespace Evol.FirstEC.Data.Repositories
{
    public class CategaryRepository : BasicEntityFrameworkRepository<Categary, FirstEcDbContext>, ICategaryRepository
    {
    }

}
