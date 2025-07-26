using System;

namespace FaMicroservice.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }
    }
}