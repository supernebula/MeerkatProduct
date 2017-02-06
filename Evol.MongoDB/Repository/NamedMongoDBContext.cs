using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Evol.Common;

namespace Evol.MongoDB.Repository
{
    public class NamedMongoDbContext : MongoClient, INamed
    {
        public string Name { get; set; }

        public IMongoClient MongoClient { get; private set; }

        public IMongoDatabase Database { get; private set; }

        protected NamedMongoDbContext(string connectionString, string databaseName)
        {
            MongoClient = new MongoClient(connectionString);
            Database = MongoClient.GetDatabase(databaseName);
        }
    }
}
