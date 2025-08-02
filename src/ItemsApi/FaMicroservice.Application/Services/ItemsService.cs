using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Domain.Interfaces;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Application.Services
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

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var result = await _itemsRepository.GetAllAsync();
            if (!result.Success)
                return [];
            return result.Items.Select(ToDTO);
        }

        public async Task<ItemDto?> GetByIdAsync(string id)
        {
            var result = await _itemsRepository.GetByIdAsync(id);
            if (!result.Success)
                return null;
            return result.Items.Select(ToDTO).FirstOrDefault();
        }

        public async Task<ItemDto?> CreateAsync(CreateItemDto item)
        {
            var result = await _itemsRepository.CreateAsync(new Item
            {
                Id = "[Id]",
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            });
            if (!result.Success)
                return null;
            return result.Items.Select(ToDTO).FirstOrDefault();
        }

        public async Task<ItemDto?> UpdateAsync(string id, UpdateItemDto item)
        {
            var result = await _itemsRepository.UpdateAsync(new Item
            {
                Id = id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            });
            if (!result.Success)
                return null;
            return result.Items.Select(ToDTO).FirstOrDefault();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _itemsRepository.DeleteAsync(id);
            if (!result.Success)
                return false;
            return true;
        }
    }
}