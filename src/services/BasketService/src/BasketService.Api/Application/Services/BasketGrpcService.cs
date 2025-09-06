using System;
using BasketService.Api.Infrastructure.Data;
using BasketService.Protos;
using Grpc.Core;
using LiteDB;
using static BasketService.Protos.BasketService;

namespace BasketService.Api.Application.Services
{
    public class BasketGrpcService(LitedbContext database) : BasketServiceBase
    {
        private readonly LitedbContext database = database;

        public override Task<Items> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var response = new Items();
            var items = database.Items.FindAll().AsEnumerable();
            if (items != null)
                response.Items_.AddRange(items);
            return Task.FromResult(response);
        }

        
    }
} 