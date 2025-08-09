using System;
using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Commands;
using MediatR;

namespace ItemService.Application.MediatR.Handlers.Commands
{
    public class UpdateCommandHandler(IItemsService itemsService) : IRequestHandler<UpdateCommand, ServiceResult>
    {
        private readonly IItemsService _itemsService = itemsService;

        public async Task<ServiceResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            return await _itemsService.UpdateAsync(request.Id, request.Item);
        }
    }
}