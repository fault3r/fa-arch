using System;

namespace FaMicroservice.Application.DTOs
{
    public record ItemDto(string Id, string Name, string Description, decimal Price, DateTime Updated);

    public record CreateItemDto(string Name, string Description, decimal Price);

    public record UpdateItemDto(string Id, string Name, string Description, decimal Price);
}