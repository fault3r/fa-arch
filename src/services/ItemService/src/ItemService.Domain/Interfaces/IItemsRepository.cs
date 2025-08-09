using System;
using ItemService.Domain.DTOs;
using ItemService.Domain.Entities;

namespace ItemService.Domain.Interfaces
{
    public interface IItemsRepository
    {
        Task<RepositoryResult> GetAllAsync();

        Task<RepositoryResult> GetByIdAsync(string id);

        Task<RepositoryResult> CreateAsync(Item item);

        Task<RepositoryResult> UpdateAsync(Item item);

        Task<RepositoryResult> DeleteAsync(string id);
    }
}