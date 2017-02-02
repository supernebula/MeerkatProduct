using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using Evol.Common;

namespace Evol.MongoDB.Repository
{
    public class NamedMongoDBContext : MongoClient, IMongoClient, INamed
    {
        public string Name { get; set; }

        public IMongoClient MongoClient { get; set; }

        protected NamedMongoDBContext(string connectionString, string databaseName)
        {
            MongoClient = new MongoClient(connectionString);
        }
    }
}
