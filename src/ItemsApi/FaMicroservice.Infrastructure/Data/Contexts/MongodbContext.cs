using System;
using FaMicroservice.Infrastructure.Configurations;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FaMicroservice.Infrastructure.Data.Contexts
{
    public class MongodbContext
    {
        private readonly IMongoDatabase database;

        private readonly MongodbSettings settings;

        public MongodbContext(IOptions<MongodbSettings> settings)
        {
            this.settings = settings.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            database = client.GetDatabase(this.settings.DatabaseName);
        }

        public IMongoCollection<ItemDocument> Items =>
            database.GetCollection<ItemDocument>(settings.CollectionName);
    }
}