using System;

namespace FaMicroservice.Application.MediatR.DTOs
{
    public record CreateItemDto(string Name, string Description, decimal Price);
}