using Evol.EntityFramework.Repository;
using Evol.FirstEC.Domain.Models.AggregateRoots;
using Evol.FirstEC.Domain.Repositories;

namespace Evol.FirstEC.Data.Repositories
{
    public class UserRepository : BasicEntityFrameworkRepository<User, FirstEcDbContext>, IUserRepository
    {
    }

}