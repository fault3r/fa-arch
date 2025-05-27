using System;
using MongoDB.Driver;
using Microsoft.Extensions;
using Microsoft.Extensions.Options;
using faApi.Infrastructure.Configurations;
using faApi.Infrastructure.Data.Contexts.Documents;

namespace faApi.Infrastructure.Data.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var url = MongoUrl.Create(settings.Value.ConnectionString);
            var client = new MongoClient(url);
            _mongoDatabase = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<BookDocument> BooksCollection =>
            _mongoDatabase.GetCollection<BookDocument>("BooksCollection");
    }
}