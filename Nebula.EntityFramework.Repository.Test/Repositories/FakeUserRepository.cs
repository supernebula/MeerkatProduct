using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Nebula.EntityFramework.Repository.Test.Core;
using Nebula.EntityFramework.Repository.Test.Entities;

namespace Nebula.EntityFramework.Repository.Test.Repositories
{
    public class FakeUserRepository : BasicEntityFrameworkRepository<FakeUser, FakeEcDbContext>
    {
        public FakeUserRepository()
        {
        }

        public FakeUserRepository(IDbContextFactory<FakeEcDbContext> dbContextFactory) : base(dbContextFactory)
        { }


        public int InsertByCommand(FakeUser item)
        {
            var sql = @"INSERT INTO [dbo].[FakeUser]
                           ([Id]
                           ,[Username]
                           ,[Password]
                           ,[RealName]
                           ,[Gender]
                           ,[Mobile]
                           ,[Email]
                           ,[Address]
                           ,[Points]
                           ,[PersonHeight]
                           ,[Birthday]
                           ,[MarkDelete]
                           ,[CreateDate])
                     VALUES
                           (@Id
                           ,@Username
                           ,@Password
                           ,@RealName
                           ,@Gender
                           ,@Mobile
                           ,@Email
                           ,@Address
                           ,@Points
                           ,@PersonHeight
                           ,@Birthday
                           ,@MarkDelete
                           ,@CreateDate)";
            return Database.ExecuteSqlCommand(sql, new SqlParameter("@Id", item.Id)
                , new SqlParameter("@Username", item.Username)
                , new SqlParameter("@Password", item.Password)
                , new SqlParameter("@RealName", item.RealName)
                , new SqlParameter("@Gender", item.Gender)
                , new SqlParameter("@Mobile", item.Mobile)
                , new SqlParameter("@Email", item.Email)
                , new SqlParameter("@Address", item.Address)
                , new SqlParameter("@Points", item.Points)
                , new SqlParameter("@PersonHeight", item.PersonHeight)
                , new SqlParameter("@Birthday", item.Birthday)
                , new SqlParameter("@MarkDelete", item.MarkDelete)
                , new SqlParameter("@CreateDate", item.CreateDate));
        }
    }
}
