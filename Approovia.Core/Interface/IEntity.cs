using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace Approovia.Core.Interface
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
