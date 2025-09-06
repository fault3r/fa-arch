using System;
using BasketService.Api.Infrastructure.Data;
using BasketService.Protos;
using Grpc.Core;
using static BasketService.Protos.BasketService;

namespace BasketService.Api.Application.Services
{
    public class BasketGrpcService(LitedbContext database) : BasketServiceBase
    {
        private readonly LitedbContext database = database;

        public override async Task<Items> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var response = new Items();
            var items = database.Items.FindAll().AsEnumerable();
            if (items != null)
                response.Items_.AddRange(items);
            return await Task.FromResult(response);
        }

        public override async Task<Item> GetById(GetByIdRequest request, ServerCallContext context)
        {
            var item = database.Items.FindOne(p => p.Id == request.Id) ??
                throw new RpcException(new Status(StatusCode.NotFound, "item not found"));
            return await Task.FromResult(item);
        }

        public override async Task<Item> Create(CreateRequest request, ServerCallContext context)
        {
            try
            {
                var item = database.Items.Insert(new Item
                {
                    Id = request.Item.Id,
                    Name = request.Item.Name,
                });
            }
            catch
            {
                throw new RpcException(new Status(StatusCode.AlreadyExists, "item already exist!"));
            }
            return await Task.FromResult(request.Item);
        }

        public override async Task<Item> Update(UpdateRequest request, ServerCallContext context)
        {
            bool update = database.Items.Update(request.Item);
            if (!update)
                throw new RpcException(new Status(StatusCode.NotFound, "item not found"));
            return await Task.FromResult(request.Item);
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            var result = database.Items.DeleteMany(p => p.Id == request.Id);
            if (result == 0)
                throw new RpcException(new Status(StatusCode.NotFound, "item not found"));
            return await Task.FromResult(new DeleteResponse { Success = result });            
        }
    }
} 