using System;
using ItemService.Domain.Entities;
using ItemService.Infrastructure.Data.Contexts.Documents.BaseDocument;

namespace ItemService.Infrastructure.Data.Contexts.Documents
{
    public class ItemDocument : MongoDocument
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public Item ToDomain()
        {
            return new Item
            {
                Id = Id.ToString(),
                Name = Name,
                Description = Description,
                Price = Price,
                Updated = Updated,
            };
        }
    }
}