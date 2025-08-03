using System;
using FaMicroservice.Domain.DTOs;
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

        public async Task<RepositoryResult> GetAllAsync()
        {
            var items = await _mongodbContext.Items.Find(mongoFilter.Empty).ToListAsync();
            return new RepositoryResult
            {
                Status = RepositoryResultStatus.Success,
                Items = items.Select(item => item.ToDomain()),
            };
        }

        public async Task<RepositoryResult> GetByIdAsync(string id)
        {
            bool checkId = ObjectId.TryParse(id, out ObjectId oid);
            if (!checkId)
                return new RepositoryResult { Status = RepositoryResultStatus.InvalidId };
            var item = await _mongodbContext.Items.Find(mongoFilter.Eq(p => p.Id, oid)).FirstOrDefaultAsync();
            if (item is null)
                return new RepositoryResult { Status = RepositoryResultStatus.NotFound };
            return new RepositoryResult
            {
                Status = RepositoryResultStatus.Success,
                Items = [item.ToDomain()],
            };
        }

        public async Task<RepositoryResult> CreateAsync(Item item)
        {
            var newItem = new ItemDocument
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Updated = DateTime.UtcNow,
            };
            await _mongodbContext.Items.InsertOneAsync(newItem);
            return new RepositoryResult
            {
                Status = RepositoryResultStatus.Success,
                Items = [newItem.ToDomain()],
            };
        }

        public async Task<RepositoryResult> UpdateAsync(Item item)
        {
            bool checkId = ObjectId.TryParse(item.Id, out ObjectId oid);
            if (!checkId)
                return new RepositoryResult { Status = RepositoryResultStatus.InvalidId };
            var updatedItem = new ItemDocument
            {
                Id = oid,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Updated = DateTime.UtcNow,
            };
            var oldItem = await _mongodbContext.Items.FindOneAndReplaceAsync(mongoFilter.Eq(prop => prop.Id, oid), updatedItem);
            if (oldItem is null)
                return new RepositoryResult { Status = RepositoryResultStatus.NotFound };
            return new RepositoryResult
            {
                Status = RepositoryResultStatus.Success,
                Items = [updatedItem.ToDomain()],
            };
        }

        public async Task<RepositoryResult> DeleteAsync(string id)
        {
            bool checkId = ObjectId.TryParse(id, out ObjectId oid);
            if (!checkId)
                return new RepositoryResult { Status = RepositoryResultStatus.InvalidId };
            var result = await _mongodbContext.Items.DeleteOneAsync(prop => prop.Id == oid);
            if (result.DeletedCount == 0)
                return new RepositoryResult { Status = RepositoryResultStatus.NotFound };
            return new RepositoryResult
            {
                Status = RepositoryResultStatus.Success,
                Items = [],
            };
        }

    }
}