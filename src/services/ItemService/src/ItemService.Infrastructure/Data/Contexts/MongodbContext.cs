using System;
using ItemService.Infrastructure.Data.Contexts.Documents;
using MongoDB.Driver;

namespace ItemService.Infrastructure.Data.Contexts
{
    public class MongodbContext(IMongoDatabase database, string collectionName)
    {
        public IMongoCollection<ItemDocument> Items =>
                database.GetCollection<ItemDocument>(collectionName);
    }
}