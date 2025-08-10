using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenericMongoRepository.Entities
{
    public interface IMongoDocument
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public DateTime Updated { get; set; }
    }
}