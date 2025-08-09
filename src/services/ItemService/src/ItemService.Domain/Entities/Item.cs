using System;

namespace ItemService.Domain.Entities
{
    public class Item
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime Updated { get; set; }
    }
}