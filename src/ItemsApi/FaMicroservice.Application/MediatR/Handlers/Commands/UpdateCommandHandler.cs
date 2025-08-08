using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Application.MediatR.Commands;
using MediatR;

namespace FaMicroservice.Application.MediatR.Handlers.Commands
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