using System;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Infrastructure.Data.Contexts.Documents.BaseDocument;

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
                Name = Name,
                Description = Description,
                Price = Price,
            };
        }

        public static ItemDocument ToDocument(Item item)
        {
            return new ItemDocument
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            };
        }
    }
}