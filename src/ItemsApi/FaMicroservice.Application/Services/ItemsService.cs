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

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _itemsRepository.GetAllAsync();
            return items.Select(ItemDTOs.ToItemDto);
        }

        public async Task<ItemDto?> GetByIdAsync(string id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            return item is null ? null : ItemDTOs.ToItemDto(item);
        }

        public async Task<ItemDto> CreateAsync(CreateItemDto item)
        {
            var nItem = await _itemsRepository.CreateAsync(new Item
            {
                Id = "[Id]",
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
            });
            return ItemDTOs.ToItemDto(nItem);
        }
        
        public async Task UpdateAsync(UpdateItemDto item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }


    }
}