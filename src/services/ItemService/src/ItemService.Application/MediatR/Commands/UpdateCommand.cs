using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.MediatR.DTOs;
using MediatR;

namespace FaMicroservice.Application.MediatR.Commands
{
    public class UpdateCommand : IRequest<ServiceResult>
    {
        public required string Id { get; set; }
        
        public required UpdateItemDto Item { get; set; }
    }
}