using Evol.EntityFramework.Repository;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace Evol.FirstEC.Data
{

    public class FirstEcDbContext : NamedDbContext
    {
        static FirstEcDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FirstEcDbContext>());
        }
        public FirstEcDbContext() : base("name=firstEcConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //方法一
            //modelBuilder.Configurations.Add(new ProductMap());

            //方法二
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
