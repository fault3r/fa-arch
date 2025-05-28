using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace faApi.Infrastructure.Data.Contexts.Documents
{
    public class BookDocument
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public int Year { get; set; }      
    }
}