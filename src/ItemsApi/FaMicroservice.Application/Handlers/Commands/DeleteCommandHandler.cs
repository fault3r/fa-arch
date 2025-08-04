using System;
using FaMicroservice.Application.Commands;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using MediatR;

namespace FaMicroservice.Application.Handlers.Commands
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