using System;
using FaMicroservice.Domain.DTOs;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Domain.Interfaces
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