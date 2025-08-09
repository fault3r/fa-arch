using System;

namespace ItemService.Application.MediatR.DTOs
{
    public record ItemDto(string Id, string Name, string Description, decimal Price, DateTime Updated);
}