using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Application.DTOs
{
    public record ItemDto(string Id, string Name, string Description, decimal Price, DateTime Updated);

    public record CreateItemDto(string Name, string Description, decimal Price);

    public record UpdateItemDto(string Id, string Name, string Description, decimal Price);

    public class ItemDTOs
    {
        public static ItemDto ToItemDto(Item item) => new(item.Id.ToString(), item.Name, item.Description, item.Price, item.Updated);
    }
}