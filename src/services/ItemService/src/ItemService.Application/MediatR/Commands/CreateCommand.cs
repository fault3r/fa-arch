using System;
using ItemService.Application.DTOs;
using ItemService.Application.MediatR.DTOs;
using MediatR;

namespace ItemService.Application.MediatR.Commands
{
    public class CreateCommand : IRequest<ServiceResult>
    {
        public required CreateItemDto Item { get; set; }     
    }
}