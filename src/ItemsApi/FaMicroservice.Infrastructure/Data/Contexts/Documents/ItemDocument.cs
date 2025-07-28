using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FaMicroservice.Infrastructure.Data.Contexts.Documents
{
    public class ItemDocument
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId MyProperty { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }
    }
}