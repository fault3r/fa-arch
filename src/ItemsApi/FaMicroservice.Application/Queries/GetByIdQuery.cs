using System;
using FaMicroservice.Application.DTOs;
using MediatR;

namespace FaMicroservice.Application.Queries
{
    public class GetByIdQuery : IRequest<ServiceResult>
    {
        public required string Id { get; set; }
    }
}