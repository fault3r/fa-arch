using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Application.DTOs
{
    public class ItemDTOs
    {
        public class ItemDto
        {
            public required string Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
            public decimal Price { get; set; }
            public DateTime Updated { get; set; }
        }
        
        public record CreateItemDto(string Name, string Description, decimal Price);

        public record UpdateItemDto(string Name, string Description, decimal Price);
    }
}