using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Domain.Interfaces
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item?> GetByIdAsync(string id);

        Task<Item?> CreateAsync(Item item);

        Task<Item?> UpdateAsync(Item item);

        Task<bool> RemoveAsync(string id);
    }
}