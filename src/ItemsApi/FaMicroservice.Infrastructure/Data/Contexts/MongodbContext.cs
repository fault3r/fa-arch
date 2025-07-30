using System;
using FaMicroservice.Infrastructure.Configurations;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FaMicroservice.Infrastructure.Data.Contexts
{
    public class MongodbContext(IOptions<MongodbSettings> settings)
    {
        public IMongoCollection<ItemDocument> Items { get; } = new MongoClient(settings.Value.ConnectionString)
                .GetDatabase(settings.Value.DatabaseName)
                .GetCollection<ItemDocument>(settings.Value.CollectionName);
    }
}