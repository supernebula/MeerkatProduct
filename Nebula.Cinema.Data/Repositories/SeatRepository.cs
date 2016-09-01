using Nebula.Cinema.Domain.Models.Entitys;
using Nebula.Cinema.Domain.Repositories;
using Nebula.EntityFramework.Repository;

namespace Nebula.Cinema.Data.Repositories
{
    public class SeatRepository : BasicEntityFrameworkRepository<Seat, CinemaDbContext>, ISeatRepository
    {
    }
}
