using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Application.MediatR.Queries;
using MediatR;

namespace FaMicroservice.Application.MediatR.Handlers.Queries
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