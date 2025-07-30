using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Domain.Interfaces
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item> GetByIdAsync(string id);

        Task CreateAsync(Item item);

        Task UpdateAsync(Item document);

        Task RemoveAsync(string id);
    }
}