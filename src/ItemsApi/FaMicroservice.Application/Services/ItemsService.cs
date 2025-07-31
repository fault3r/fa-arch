using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Domain.Interfaces;

namespace FaMicroservice.Application.Services
{
    public class ItemsService(IItemsRepository itemsRepository) : IItemsService
    {
        private readonly IItemsRepository _itemsRepository = itemsRepository;

        private static ItemDto toItemDto(Item item)
        {
            return new ItemDto(item.Id.ToString(), item.Name, item.Description, item.Price, item.Updated);
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _itemsRepository.GetAllAsync();
            return items.Select(item => toItemDto(item));
        }

        public async Task<ItemDto?> GetByIdAsync(string id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            return item is null ? null : toItemDto(item);
        }

        public async Task CreateAsync(CreateItemDto item)
        {
            await _itemsRepository.CreateAsync(new Item
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            });
        }

        public async Task UpdateAsync(UpdateItemDto item)
        {
            await _itemsRepository.UpdateAsync(new Item
            {
                Id = Guid.Parse(item.Id),
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            });
        }
        
        public async Task RemoveAsync(string id)
        {
            await _itemsRepository.RemoveAsync(id);
        }
    }
}