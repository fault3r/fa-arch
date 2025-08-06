using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Domain.DTOs;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Domain.Interfaces;
using static FaMicroservice.Application.DTOs.ItemDTOs;
using static FaMicroservice.Application.DTOs.ServiceResult;

namespace FaMicroservice.Application.Services
{
    public class ItemsService(IItemsRepository itemsRepository) : IItemsService
    {
        private readonly IItemsRepository _itemsRepository = itemsRepository;

        private static ItemDto ToDTO(Item item) => new()
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Updated = item.Updated
        };

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
            RepositoryResult result = await _itemsRepository.GetByIdAsync(id);
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