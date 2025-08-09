using System;
using ItemService.Application.DTOs;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.DTOs;
using ItemService.Domain.DTOs;
using ItemService.Domain.Entities;
using ItemService.Domain.Interfaces;
using static ItemService.Application.DTOs.ServiceResult;

namespace ItemService.Application.Services
{
    public class ItemsService(IItemsRepository itemsRepository) : IItemsService
    {
        private readonly IItemsRepository _itemsRepository = itemsRepository;

        private static ItemDto ToDTO(Item item) => new(
            item.Id,
            item.Name,
            item.Description,
            item.Price,
            item.Updated);

        public async Task<ServiceResult> GetAllAsync()
        {
            var result = await _itemsRepository.GetAllAsync();
            return new ServiceResult
            {
                Status = ServiceResultStatus.Ok,
                Items = result.Items.Select(ToDTO),
            };
        }

        public async Task<ServiceResult> GetByIdAsync(string id)
        {
            var result = await _itemsRepository.GetByIdAsync(id);
            if (result.Status == RepositoryResultStatus.InvalidId)
                return new ServiceResult { Status = ServiceResultStatus.BadRequest };
            else if (result.Status == RepositoryResultStatus.NotFound)
                return new ServiceResult { Status = ServiceResultStatus.NotFound };
            return new ServiceResult
            {
                Status = ServiceResultStatus.Ok,
                Items = result.Items.Select(ToDTO),
            };
        }

        public async Task<ServiceResult> CreateAsync(CreateItemDto item)
        {
            if(item is null)
                return new ServiceResult { Status = ServiceResultStatus.BadRequest };
            var result = await _itemsRepository.CreateAsync(new Item
            {
                Id = "[NewId]",
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            });
            return new ServiceResult
            {
                Status = ServiceResultStatus.Created,
                Items = result.Items.Select(ToDTO),
            };
        }

        public async Task<ServiceResult> UpdateAsync(string id, UpdateItemDto item)
        {
            if (item is null)
                return new ServiceResult { Status = ServiceResultStatus.BadRequest };
            var result = await _itemsRepository.UpdateAsync(new Item
            {
                Id = id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            });
            if (result.Status == RepositoryResultStatus.InvalidId)
                return new ServiceResult { Status = ServiceResultStatus.BadRequest };
            else if (result.Status == RepositoryResultStatus.NotFound)
                return new ServiceResult { Status = ServiceResultStatus.NotFound};
            return new ServiceResult
            {
                Status = ServiceResultStatus.Ok,
                Items = result.Items.Select(ToDTO),
            };
        }

        public async Task<ServiceResult> DeleteAsync(string id)
        {
            var result = await _itemsRepository.DeleteAsync(id);
            if (result.Status == RepositoryResultStatus.InvalidId)
                return new ServiceResult { Status = ServiceResultStatus.BadRequest };
            else if (result.Status == RepositoryResultStatus.NotFound)
                return new ServiceResult { Status = ServiceResultStatus.NotFound };
            return new ServiceResult { Status = ServiceResultStatus.NoContent };
        }

    }
}