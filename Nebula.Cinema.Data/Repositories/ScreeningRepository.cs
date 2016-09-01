using Nebula.Cinema.Domain.Models.AggregateRoots;
using Nebula.Cinema.Domain.Repositories;
using Nebula.EntityFramework.Repository;

namespace Nebula.Cinema.Data.Repositories
{
    public class ScreeningRepository : BasicEntityFrameworkRepository<Screening, CinemaDbContext>, IScreeningRepository
    {
    }
}
