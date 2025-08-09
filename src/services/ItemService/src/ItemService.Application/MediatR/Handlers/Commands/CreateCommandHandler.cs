using System;
using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Commands;
using MediatR;

namespace ItemService.Application.MediatR.Handlers.Commands
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