using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using Nebula.Test.Model;

namespace Nebula.Dapper.Repository.Test
{
    public class FakeUserRepository : BasicDapperRepository<FakeUser, FakeEcDbContext>
    {
        public FakeUserRepository(IDbConnectionFactory<FakeEcDbContext> dbContext) : base(dbContext)
        {
        }

        public List<FakeUser> Take(int num = 0)
        {
            string sql = null;
            if (num <= 0)
                sql = "SELECT * FROM [FakeUser]";
            else
                sql = "SELECT TOP " + num + " * FROM [FakeUser]";
            return this.Query(sql).ToList();
        }
    }
}
