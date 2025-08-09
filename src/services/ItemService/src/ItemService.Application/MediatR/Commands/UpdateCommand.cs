using System;
using ItemService.Application.DTOs;
using ItemService.Application.MediatR.DTOs;
using MediatR;

namespace ItemService.Application.MediatR.Commands
{
    public class UpdateCommand : IRequest<ServiceResult>
    {
        public required string Id { get; set; }
        
        public required UpdateItemDto Item { get; set; }
    }
}