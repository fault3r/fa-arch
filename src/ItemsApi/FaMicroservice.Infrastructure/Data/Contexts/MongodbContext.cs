using System;
using FaMicroservice.Infrastructure.Configurations;
using FaMicroservice.Infrastructure.Data.Contexts.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FaMicroservice.Infrastructure.Data.Contexts
{
    public class MongodbContext
    {
        private readonly IMongoDatabase mongoDatabase;

        public MongodbContext(IOptions<MongodbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            mongoDatabase = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoDatabase MongoDatabase => mongoDatabase;
    }
}