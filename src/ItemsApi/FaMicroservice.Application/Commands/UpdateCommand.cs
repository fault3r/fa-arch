using System;
using FaMicroservice.Application.DTOs;
using MediatR;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Application.Commands
{
    public class UpdateCommand : IRequest<ServiceResult>
    {
        public required string Id { get; set; }
        
        public required UpdateItemDto Item { get; set; }
    }
}