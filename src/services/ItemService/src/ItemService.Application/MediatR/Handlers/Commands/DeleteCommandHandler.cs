using System;
using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Commands;
using MediatR;

namespace ItemService.Application.MediatR.Handlers.Commands
{
    public class DeleteCommandHandler(IItemsService itemsService) : IRequestHandler<DeleteCommand, ServiceResult>
    {
        private readonly IItemsService _itemsService = itemsService;

        public async Task<ServiceResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await _itemsService.DeleteAsync(request.Id);
        }
    }
}