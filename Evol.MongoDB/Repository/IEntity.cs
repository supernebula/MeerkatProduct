using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Evol.MongoDB.Repository
{
    public interface IEntity<TKey>
    {
        [BsonId]
        TKey Id { get; set; }

        DateTime CreateTime { get; set; }
    }

    public interface IEntity : IEntity<string>
    {
    }
}
