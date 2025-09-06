using System;
using BasketService.Protos;
using LiteDB;

namespace BasketService.Api.Infrastructure.Data
{
    public class LitedbContext
    {
        public ILiteCollection<Item> Items;

        public LitedbContext(LiteDatabase database, string collection)
        {
            Items = database.GetCollection<Item>(collection);
        }
        
    }
}