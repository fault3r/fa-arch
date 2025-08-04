using System;
using FaMicroservice.Application.DTOs;
using MediatR;

namespace FaMicroservice.Application.Commands
{
    public class DeleteCommand : IRequest<ServiceResult>
    {
        public required string Id { get; set; }
    }
}