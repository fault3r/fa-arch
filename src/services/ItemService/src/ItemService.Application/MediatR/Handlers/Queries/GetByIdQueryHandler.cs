using System;
using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Queries;
using MediatR;

namespace ItemService.Application.MediatR.Handlers.Queries
{
    public class GetByIdQueryHandler(IItemsService itemsService) : IRequestHandler<GetByIdQuery, ServiceResult>
    {
        private readonly IItemsService _itemsService = itemsService;

        public async Task<ServiceResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _itemsService.GetByIdAsync(request.Id);
        }
    }
}