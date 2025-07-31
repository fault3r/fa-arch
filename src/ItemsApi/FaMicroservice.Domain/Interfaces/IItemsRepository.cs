using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Domain.Interfaces
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item?> GetByIdAsync(string id);

        Task CreateAsync(Item item);

        Task UpdateAsync(Item item);

        Task RemoveAsync(string id);
    }
}