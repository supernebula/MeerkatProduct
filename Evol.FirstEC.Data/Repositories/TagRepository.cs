using Evol.EntityFramework.Repository;
using Evol.FirstEC.Domain.Models.AggregateRoots;
using Evol.FirstEC.Domain.Repositories;

namespace Evol.FirstEC.Data.Repositories
{
    public class TagRepository : BasicEntityFrameworkRepository<Tag, FirstEcDbContext>, ITagRepository
    {
    }

}