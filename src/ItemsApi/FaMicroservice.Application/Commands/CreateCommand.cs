using System;
using FaMicroservice.Application.DTOs;
using MediatR;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Application.Commands
{
    public class CreateCommand : IRequest<ServiceResult>
    {
        public required CreateItemDto Item { get; set; }     
    }
}