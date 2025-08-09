using System;
using ItemService.Infrastructure.Configurations;
using ItemService.Infrastructure.Data.Contexts.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ItemService.Infrastructure.Data.Contexts
{
    public class MongodbContext(IOptions<MongodbSettings> settings)
    {
        public IMongoCollection<ItemDocument> Items { get; } =
            new MongoClient(settings.Value.ConnectionString)
                .GetDatabase(settings.Value.DatabaseName)
                .GetCollection<ItemDocument>(settings.Value.CollectionName);
    }
}