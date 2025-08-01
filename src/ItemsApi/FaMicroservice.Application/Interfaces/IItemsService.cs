using System;
using FaMicroservice.Application.DTOs;

namespace FaMicroservice.Application.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();

        Task<ItemDto?> GetByIdAsync(string id);

        Task<ItemDto?> CreateAsync(CreateItemDto item);

        Task UpdateAsync(UpdateItemDto item);

        Task RemoveAsync(string id);
    }
}