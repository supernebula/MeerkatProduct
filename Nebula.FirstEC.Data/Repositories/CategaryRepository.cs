using Nebula.FirstEC.Domain.Repositories;
using Nebula.EntityFramework.Repository;
using Nebula.FirstEC.Domain.Models.AggregateRoots;

namespace Nebula.FirstEC.Data.Repositories
{
    public class CategaryRepository : BasicEntityFrameworkRepository<Categary, FirstEcDbContext>, ICategaryRepository
    {
    }

}
