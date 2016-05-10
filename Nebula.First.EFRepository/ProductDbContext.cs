using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Nebula.First.EFRepository.Map;
using Nebula.First.EFRepository.Model;

namespace Nebula.First.EFRepository
{
    public class ProductDbContext : DbContext
    {
        private static ProductDbContext _instance;

        public static ProductDbContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductDbContext();
                return _instance;
            }
        }

    static ProductDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProductDbContext>());
        }
        public ProductDbContext() : base("name=productContext")
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
