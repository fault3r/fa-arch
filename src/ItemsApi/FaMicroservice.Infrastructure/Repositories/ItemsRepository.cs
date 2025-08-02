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
                var item = await _mongodbContext.Items.Find(mongoFilter.Eq(p => p.Id, ObjectId.Parse(id))).FirstOrDefaultAsync();
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
                var nItem = new ItemDocument
                {
                    Id = ObjectId.Parse(item.Id),
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Updated = DateTime.UtcNow,
                };
                var updateItem = await _mongodbContext.Items.FindOneAndReplaceAsync(mongoFilter.Eq(prop => prop.Id, ObjectId.Parse(item.Id)), nItem);
                if (updateItem is null)
                    return new RepositoryResult { Message = "Not Found!" };
                return new RepositoryResult
                {
                    Success = true,
                    Message = "Success.",
                    Items = [nItem.ToDomain()],
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
                var res = await _mongodbContext.Items.DeleteOneAsync(prop => prop.Id == ObjectId.Parse(id));
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