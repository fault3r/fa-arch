using System;
using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Queries;
using MediatR;

namespace ItemService.Application.MediatR.Handlers.Queries
{
    public class GetAllQueryHandler(IItemsService itemsService) : IRequestHandler<GetAllQuery, ServiceResult>
    {
        private readonly IItemsService _itemsService = itemsService;

        public async Task<ServiceResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _itemsService.GetAllAsync();
        }
    }
}