using System;

namespace FaMicroservice.Application.MediatR.DTOs
{
    public record UpdateItemDto(string Name, string Description, decimal Price);
}