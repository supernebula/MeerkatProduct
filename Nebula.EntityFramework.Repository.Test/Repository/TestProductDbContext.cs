using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nebula.EntityFramework.Repository.Test.Map;

namespace Nebula.EntityFramework.Repository.Test.Repository
{
    class TestProductDbContext : DbContext
    {
        private static TestProductDbContext _instance;

        public static TestProductDbContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestProductDbContext();
                return _instance;
            }
        }

        static TestProductDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TestProductDbContext>());
        }
        public TestProductDbContext() : base("name=testProductContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<TestProductMap> Pruducts { get; set; }

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
