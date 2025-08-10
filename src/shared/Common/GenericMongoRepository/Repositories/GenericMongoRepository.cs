using System;
using GenericMongoRepository.Entities;
using GenericMongoRepository.Interfaces;

namespace GenericMongoRepository.Repositories
{
    public class GenericMongoRepository<TEntity, TDocument> : IGenericMongoRepository<TEntity, TDocument>
        where TEntity : IEntity
        where TDocument : IMongoDocument
    {
        public Task<IEntity?> CreateAsync(IEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEntity?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity?> UpdateAsync(IEntity item)
        {
            throw new NotImplementedException();
        }
    }
}