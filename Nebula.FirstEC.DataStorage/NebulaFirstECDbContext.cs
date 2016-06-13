using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.FirstEC.Compoment;
using Nebula.FirstEC.Compoment.AggregateRoots;
using Nebula.FirstEC.DataStorage.Map;

namespace Nebula.FirstEC.DataStorage
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
