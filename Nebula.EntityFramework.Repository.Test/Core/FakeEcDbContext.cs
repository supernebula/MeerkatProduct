using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Nebula.EntityFramework.Repository.Test.Map;

namespace Nebula.EntityFramework.Repository.Test.Core
{
    public class FakeEcDbContext : DbContext 
    {

        static FakeEcDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FakeEcDbContext>());
        }

        public FakeEcDbContext() : base("name=fakeEcDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FakeProductMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
