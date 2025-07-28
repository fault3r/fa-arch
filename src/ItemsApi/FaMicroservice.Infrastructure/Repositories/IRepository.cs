using System;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;

namespace FaMicroservice.Infrastructure.Repositories
{
    public interface IRepository<T> where T : IDocument
    {
        Task CreateAsync(T document);

        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task<T> GetAsync(string id);

        Task RemoveAsync(string id);

        Task UpdateAsync(T document);
    }
}