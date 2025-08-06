using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Application.DTOs
{
    public class ItemDTOs
    {
        public record ItemDto(string Id, string Name, string Description, decimal Price, DateTime Updated);
        
        public record CreateItemDto(string Name, string Description, decimal Price);

        public record UpdateItemDto(string Name, string Description, decimal Price);
    }
}