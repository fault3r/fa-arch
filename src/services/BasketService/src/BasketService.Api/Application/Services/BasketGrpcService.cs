using System;
using BasketService.Protos;
using Grpc.Core;
using LiteDB;
using static BasketService.Protos.BasketService;

namespace BasketService.Api.Application.Services
{
    public class BasketGrpcService : BasketServiceBase
    {
        private readonly LiteDatabase liteDatabase;
        public BasketGrpcService()
        {
            liteDatabase = new LiteDatabase(@"basketdb.db");
        }

        public override Task<Items> GetAll(GetAllRequest request, ServerCallContext context)
        {
            return base.GetAll(request, context);
        }

        public override Task<Item> GetById(GetByIdRequest request, ServerCallContext context)
        {
            return base.GetById(request, context);
        }
    }
} 