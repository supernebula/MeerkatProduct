using Nebula.EntityFramework.Repository;
using Nebula.FirstEC.Domain.Models.Entities;
using Nebula.FirstEC.Domain.Repositories;

namespace Nebula.FirstEC.Data.Repositories
{
    public class CategarySpecRelationRepository : BasicEntityFrameworkRepository<CategarySpecRelation, FirstEcDbContext>, ICategarySpecRelationRepository
    {
    }

}
