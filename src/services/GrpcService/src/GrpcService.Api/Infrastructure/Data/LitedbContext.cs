using System;
using GrpcService.Protos;
using LiteDB;

namespace GrpcService.Api.Infrastructure.Data
{
    public class LitedbContext(LiteDatabase database, string collection)
    {
        public ILiteCollection<Item> Items => database.GetCollection<Item>(collection);
    }
}