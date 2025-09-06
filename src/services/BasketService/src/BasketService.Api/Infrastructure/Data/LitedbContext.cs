using System;
using BasketService.Protos;
using LiteDB;

namespace BasketService.Api.Infrastructure.Data
{
    public class LitedbContext(LiteDatabase database, string collection)
    {
        public ILiteCollection<Item> Items => database.GetCollection<Item>(collection);
    }
}