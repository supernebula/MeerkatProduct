using System.Data;

namespace Nebula.Dapper.Repository
{
    public interface IDbConnectionFactory<out TDbConnection> where TDbConnection : IDbConnection
    {
        TDbConnection Create();
    }
}
