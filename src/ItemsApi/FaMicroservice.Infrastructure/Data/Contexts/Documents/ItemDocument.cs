using System;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Infrastructure.Data.Contexts.Documents.BaseDocument;
using FaMicroservice.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FaMicroservice.Infrastructure.Data.Contexts.Documents
{
    public class ItemDocument : IDocument
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public Item ToDomain()
        {
            return new Item
            {
                Id = Guid.Parse(Id.ToString()),
                Name = Name,
                Description = Description,
                Price = Price,
                Updated = DateTime.UtcNow,
            };
        }

        public static ItemDocument ToDocument(Item item)
        {
            return new ItemDocument
            {
                Id = ObjectId.Parse(item.Id.ToString()),
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Updated = item.Updated,
            };
        }
    }
}