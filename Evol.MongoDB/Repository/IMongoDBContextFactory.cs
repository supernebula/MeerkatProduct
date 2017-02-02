
namespace Evol.MongoDB.Repository
{
    public interface IMongoDBContextFactory
    {
        TDbContext Get<TDbContext>() where TDbContext : NamedMongoDBContext;
    }
}
