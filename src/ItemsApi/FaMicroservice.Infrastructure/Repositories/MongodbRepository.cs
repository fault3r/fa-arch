using System;
using FaMicroservice.Infrastructure.Data.Contexts;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;
using MongoDB.Driver;

namespace FaMicroservice.Infrastructure.Repositories
{
    public class MongodbRepository<T> : IRepository<T> where T : IDocument
    {
        private readonly MongodbContext _mongodbContext;

        private readonly IMongoCollection<T> collection;

        public MongodbRepository(MongodbContext mongodbContext)
        {
            _mongodbContext = mongodbContext;
            collection = _mongodbContext.MongoDatabase.GetCollection<T>(nameof(T));
        }

        public async Task CreateAsync(T document)
        {
            await collection.InsertOneAsync(document);
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