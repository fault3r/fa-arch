using System;
using ItemService.Application.DTOs;
using MediatR;

namespace ItemService.Application.MediatR.Queries
{
    public class GetByIdQuery : IRequest<ServiceResult>
    {
        public required string Id { get; set; }
    }
}