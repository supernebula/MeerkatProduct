using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Evol.MongoDB.Repository
{
    public abstract class BaseMongoDBRepository<T, TMongoDBContext> where TMongoDBContext : NamedMongoDBContext, new() where T : class
    {
        private TMongoDBContext _mongoDBContext { get; set; }

        private IMongoDatabase _database { get; set; }



        public BaseMongoDBRepository()
        {
        }
    }
}
