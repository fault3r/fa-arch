using System;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;

namespace FaMicroservice.Infrastructure.Repositories
{
    public class MongodbRepository<T> : IRepository<T> where T : IDocument
    {
        public Task CreateAsync(T document)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T document)
        {
            throw new NotImplementedException();
        }
    }
}