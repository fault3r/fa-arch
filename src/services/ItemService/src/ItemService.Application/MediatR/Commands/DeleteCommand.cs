using System;
using ItemService.Application.DTOs;
using MediatR;

namespace ItemService.Application.MediatR.Commands
{
    public class DeleteCommand : IRequest<ServiceResult>
    {
        public required string Id { get; set; }
    }
}