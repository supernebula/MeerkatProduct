using Nebula.EntityFramework.Repository;
using Nebula.FirstEC.Domain.Models.AggregateRoots;
using Nebula.FirstEC.Domain.Repositories;

namespace Nebula.FirstEC.Data.Repositories
{
    public class ShoppingCartRepository : BasicEntityFrameworkRepository<ShoppingCart, FirstEcDbContext>, IShoppingCartRepository
    {

    }

}