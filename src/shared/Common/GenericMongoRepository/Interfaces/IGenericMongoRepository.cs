using System;
using GenericMongoRepository.Entities;

namespace GenericMongoRepository.Interfaces
{
    public interface IGenericMongoRepository<TEntity, TDocument>
        where TEntity : IEntity
        where TDocument : IMongoDocument
    {
        Task<IEnumerable<IEntity>> GetAllAsync();

        Task<IEntity?> GetByIdAsync(string id);

        Task<IEntity?> CreateAsync(IEntity item);

        Task<IEntity?> UpdateAsync(IEntity item);

        Task<bool> DeleteAsync(string id);
    }
}