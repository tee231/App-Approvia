
using Approovia.Core.Interface;
using MongoDB.Bson;
using System;


namespace Approovia.Data.Entities
{
    public abstract class Entities : IEntity
    {

       
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;

    }
}
