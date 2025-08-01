using System;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Domain.Interfaces;
using FaMicroservice.Infrastructure.Data.Contexts;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;
using MongoDB.Bson;
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
            var item = await _mongodbContext.Items.Find(mongoFilter.Eq(p => p.Id, ObjectId.Parse(id))).FirstOrDefaultAsync();
            return item?.ToDomain();
        }

        public async Task<Item?> CreateAsync(Item item)
        {
            var nItem = new ItemDocument
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Updated = DateTime.UtcNow,
            };
            await _mongodbContext.Items.InsertOneAsync(nItem);
            return nItem.ToDomain();
        }

        Task<Item?> IItemsRepository.UpdateAsync(Item item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IItemsRepository.RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}