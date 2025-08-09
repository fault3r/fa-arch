using System;

namespace ItemService.Application.MediatR.DTOs
{
    public record CreateItemDto(string Name, string Description, decimal Price);
}