using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.MediatR.DTOs;
using MediatR;

namespace FaMicroservice.Application.MediatR.Commands
{
    public class CreateCommand : IRequest<ServiceResult>
    {
        public required CreateItemDto Item { get; set; }     
    }
}