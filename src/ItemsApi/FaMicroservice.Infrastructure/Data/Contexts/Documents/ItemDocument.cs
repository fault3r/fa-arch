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
                Id = Id.ToString(),
                Name = Name,
                Description = Description,
                Price = Price,
                Updated = Updated,
            };
        }
    }
}