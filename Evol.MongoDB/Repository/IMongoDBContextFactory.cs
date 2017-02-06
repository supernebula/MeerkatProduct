
namespace Evol.MongoDB.Repository
{
    public interface IMongoDbContextFactory
    {
        TDbContext Get<TDbContext>() where TDbContext : NamedMongoDbContext, new();
    }
}
