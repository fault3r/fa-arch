using System;
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

        public record RepositoryResult
        {
            public bool Success { get; set; } = false;

            public string Message { get; set; } = "";

            public IEnumerable<Item> Items { get; set; } = [];
        }
    }


}