using System;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Application.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();

        Task<ItemDto?> GetByIdAsync(string id);

        Task<ItemDto?> CreateAsync(CreateItemDto item);

        Task<ItemDto?> UpdateAsync(string id, UpdateItemDto item);

        Task<bool> DeleteAsync(string id);
    }
}