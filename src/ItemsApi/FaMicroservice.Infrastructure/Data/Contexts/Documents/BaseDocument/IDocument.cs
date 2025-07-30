using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FaMicroservice.Infrastructure.Data.Contexts.Documents.BaseDocument
{
    public class IDocument
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public DateTime Updated { get; set; }
    }
}