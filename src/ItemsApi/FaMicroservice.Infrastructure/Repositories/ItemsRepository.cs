using System;
using FaMicroservice.Domain.Entities;
using FaMicroservice.Domain.Interfaces;
using FaMicroservice.Infrastructure.Data.Contexts;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;
using MongoDB.Bson;
using MongoDB.Driver;
using static FaMicroservice.Domain.Interfaces.IItemsRepository;

namespace FaMicroservice.Infrastructure.Repositories
{
    public class ItemsRepository(MongodbContext mongodbContext) : IItemsRepository
    {
        private readonly MongodbContext _mongodbContext = mongodbContext;

        private readonly FilterDefinitionBuilder<ItemDocument> mongoFilter = Builders<ItemDocument>.Filter;


        public async Task<RepositoryResult> GetAllAsync()
        {
            try
            {
                var items = await _mongodbContext.Items.Find(mongoFilter.Empty).ToListAsync();
                return new RepositoryResult
                {
                    Success = true,
                    Message = "Success.",
                    Items = items.Select(item => item.ToDomain()),
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult { Message = $"Database Error!\n{ex.Message}" };
            }
        }

        public async Task<RepositoryResult> GetByIdAsync(string id)
        {
            try
            {
                bool checkId = ObjectId.TryParse(id, out ObjectId oid);
                if(!checkId)
                    return new RepositoryResult { Message = "Invalid Id!" };
                var item = await _mongodbContext.Items.Find(mongoFilter.Eq(p => p.Id, oid)).FirstOrDefaultAsync();
                if (item is null)
                    return new RepositoryResult { Message = "Not Found!" };
                return new RepositoryResult
                {
                    Success = true,
                    Message = "Success.",
                    Items = [item.ToDomain()],
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult { Message = $"Database Error!\n{ex.Message}" };
            }
        }

        public async Task<RepositoryResult> CreateAsync(Item item)
        {
            try
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
                    Success = true,
                    Message = "Success.",
                    Items = [newItem.ToDomain()],
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult { Message = $"Database Error!\n{ex.Message}" };
            }
        }

        public async Task<RepositoryResult> UpdateAsync(Item item)
        {
            try
            {
                bool checkId = ObjectId.TryParse(item.Id, out ObjectId oid);
                if(!checkId)
                    return new RepositoryResult { Message = "Invalid Id!" };
                var newItem = new ItemDocument
                {
                    Id = oid,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Updated = DateTime.UtcNow,
                };
                var oldItem = await _mongodbContext.Items.FindOneAndReplaceAsync(mongoFilter.Eq(prop => prop.Id, oid), newItem);
                if (oldItem is null)
                    return new RepositoryResult { Message = "Not Found!" };
                return new RepositoryResult
                {
                    Success = true,
                    Message = "Success.",
                    Items = [newItem.ToDomain()],
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult { Message = $"Database Error!\n{ex.Message}" };
            }
        }

        public async Task<RepositoryResult> DeleteAsync(string id)
        {
            try
            {
                var result = await _mongodbContext.Items.DeleteOneAsync(prop => prop.Id == ObjectId.Parse(id));
                if (result.DeletedCount == 0)
                    return new RepositoryResult { Message = "Not Found!" };
                return new RepositoryResult
                {
                    Success = true,
                    Message = "Success.",
                    Items = [],
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult { Message = $"Database Error!\n{ex.Message}" };
            }
        }
    }
}