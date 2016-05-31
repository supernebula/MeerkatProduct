using System.Data;

namespace Nebula.Dapper.Repository
{
    public interface IDbConnectionFactory<out TDbContext> where TDbContext : DapperDbContext
    {
        TDbContext Create();
    }
}
