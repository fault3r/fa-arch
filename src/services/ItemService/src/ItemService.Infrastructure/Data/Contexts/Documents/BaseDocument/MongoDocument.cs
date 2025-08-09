using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ItemService.Infrastructure.Data.Contexts.Documents.BaseDocument
{
    public class MongoDocument
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public DateTime Updated { get; set; }
    }
}