using System;

namespace ItemService.Application.MediatR.DTOs
{
    public record UpdateItemDto(string Name, string Description, decimal Price);
}