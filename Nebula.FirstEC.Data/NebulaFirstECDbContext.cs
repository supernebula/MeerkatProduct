using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Nebula.FirstEC.Data.Map;
using Nebula.FirstEC.Domain.Models.AggregateRoots;

namespace Nebula.FirstEC.Data
{

    public class NebulaFirstEcDbContext : DbContext
    {
        static NebulaFirstEcDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NebulaFirstEcDbContext>());
        }
        public NebulaFirstEcDbContext() : base("name=nebulaFirstECDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Pruducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }
    }
}
