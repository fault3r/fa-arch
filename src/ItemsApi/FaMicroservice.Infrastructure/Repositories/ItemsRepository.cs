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

        private readonly FilterDefinitionBuilder<ItemDocument> mongoFilter = Builders<ItemDocument>.Filter;

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _mongodbContext.Items.Find(mongoFilter.Empty).ToListAsync();
            return items.Select(item => item.ToDomain());
        }

        public async Task<Item?> GetByIdAsync(string id)
        {
            var item = await _mongodbContext.Items.Find(mongoFilter.Eq(prop => prop.Id.ToString(), id)).FirstOrDefaultAsync();
            return item?.ToDomain();
        }

        public async Task CreateAsync(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);
            item.Updated = DateTime.UtcNow;
            await _mongodbContext.Items.InsertOneAsync(ItemDocument.ToDocument(item));
        }

        public async Task UpdateAsync(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);
            var old = GetByIdAsync(item.Id.ToString());
            ArgumentNullException.ThrowIfNull(old);
            item.Updated = DateTime.UtcNow;
            await _mongodbContext.Items.ReplaceOneAsync(prop => prop.Id.ToString() == item.Id.ToString(),
                ItemDocument.ToDocument(item));
        }

        public async Task RemoveAsync(string id)
        {
            await _mongodbContext.Items.DeleteOneAsync(mongoFilter.Eq(prop => prop.Id.ToString(), id));
        }
    }
}