using System;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Application.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();

        Task<ItemDto?> GetByIdAsync(string id);

        Task<ItemDto> CreateAsync(CreateItemDto item);

        Task UpdateAsync(UpdateItemDto item);

        Task RemoveAsync(string id);
    }
}