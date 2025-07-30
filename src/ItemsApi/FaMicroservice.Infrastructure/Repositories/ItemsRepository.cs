using System;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Domain.Interfaces;
using FaMicroservice.Infrastructure.Data.Contexts;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;
using MongoDB.Driver;

namespace FaMicroservice.Infrastructure.Repositories
{
    public class ItemsRepository(MongodbContext mongodbContext) : IItemsRepository
    {
        private readonly MongodbContext _mongodbContext = mongodbContext;

        private readonly FilterDefinitionBuilder<ItemDocument> filter = Builders<ItemDocument>.Filter;


        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _mongodbContext.Items.FindAsync(filter.Empty);
            return items.ToList().Select(r => r.ToDomain());
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            var item = await _mongodbContext.Items.FindAsync(filter.Eq(p => p.Id.ToString(), id));
        }

        public async Task CreateAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Item document)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}