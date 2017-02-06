using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Evol.MongoDB.Repository
{
    public abstract class BaseMongoDbRepository<T, TMongoDbContext> where TMongoDbContext : NamedMongoDbContext, new() where T : class
    {
        private TMongoDbContext MongoDbContext => MongoDbContextFactory.Get<TMongoDbContext>();

        protected IMongoDatabase Database => MongoDbContext.Database;

        protected IMongoCollection<T> Collection => Database.GetCollection<T>(nameof(T));

        [Dependency]
        public IMongoDbContextFactory MongoDbContextFactory { get; set; }

        protected BaseMongoDbRepository()
        {
        }

        protected BaseMongoDbRepository(IMongoDbContextFactory mongoDbContextFactory)
        {
            MongoDbContextFactory = mongoDbContextFactory;
        }

        //public T Find(ObjectId id)
        //{
        //    //Collection.Find(e => e)
        //}
    }
}
