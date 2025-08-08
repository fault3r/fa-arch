using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Application.MediatR.Queries;
using MediatR;

namespace FaMicroservice.Application.MediatR.Handlers.Queries
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