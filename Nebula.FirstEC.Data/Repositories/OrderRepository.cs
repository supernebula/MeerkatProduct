using Nebula.EntityFramework.Repository;
using Nebula.FirstEC.Domain.Models.AggregateRoots;
using Nebula.FirstEC.Domain.Repositories;

namespace Nebula.FirstEC.Data.Repositories
{
    public class OrderRepository : BasicEntityFrameworkRepository<Order, FirstEcDbContext>, IOrderRepository
    {

    }

}