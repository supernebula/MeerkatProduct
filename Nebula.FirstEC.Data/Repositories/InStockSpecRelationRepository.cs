using Evol.EntityFramework.Repository;
using Evol.FirstEC.Domain.Models.Entities;
using Evol.FirstEC.Domain.Repositories;

namespace Evol.FirstEC.Data.Repositories
{
    public class InStockSpecRelationRepository : BasicEntityFrameworkRepository<InStockSpecRelation, FirstEcDbContext>, IInStockSpecRelationRepository
    { 

    }

}