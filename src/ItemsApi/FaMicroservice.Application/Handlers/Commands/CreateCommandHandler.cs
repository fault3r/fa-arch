using System;
using FaMicroservice.Application.Commands;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using MediatR;

namespace FaMicroservice.Application.Handlers.Commands
{
    public class CreateCommandHandler(IItemsService itemsService) : IRequestHandler<CreateCommand, ServiceResult>
    {
        private readonly IItemsService _itemsService = itemsService;

        public async Task<ServiceResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return await _itemsService.CreateAsync(request.Item);
        }
    }
}