using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FaMicroservice.Infrastructure.Data.Contexts.Documents
{
    public interface IDocument
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    }
}