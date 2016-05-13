using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Nebula.EntityFramework.Repository.Test.Map;

namespace Nebula.EntityFramework.Repository.Test
{
    public class TestEcDbContext : DbContext 
    {

        static TestEcDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TestEcDbContext>());
        }

        public TestEcDbContext() : base("name=testEcDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TestProductMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
