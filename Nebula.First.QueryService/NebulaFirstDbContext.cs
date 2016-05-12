//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Nebula.FirstEC.DataStorage
//{

//    public class NebulaFirstDbContext : DbContext
//    {
//        private static NebulaFirstDbContext _instance;

//        public static NebulaFirstDbContext Instance
//        {
//            get
//            {
//                if (_instance == null)
//                    _instance = new NebulaFirstDbContext();
//                return _instance;
//            }
//        }

//        static ProductDbContext()
//        {
//            Database.SetInitializer(new CreateDatabaseIfNotExists<NebulaFirstDbContext>());
//        }
//        public ProductDbContext() : base("name=productContext")
//        {
//            Configuration.LazyLoadingEnabled = false;
//        }

//        public DbSet<Product> Pruducts { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {

//            modelBuilder.Configurations.Add(new ProductMap());
//            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
//            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//            base.OnModelCreating(modelBuilder);

//        }
//    }
//}
