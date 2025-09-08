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

        public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var items = database.Items.FindAll();
            var response = new GetAllResponse
            {
                Status = new ServiceResult
                {
                    Success = true,
                    Message = "success.",
                },
            };
            response.Items.Add(items);
            return await Task.FromResult(response);
        }

        public override async Task<GetByIdResponse> GetById(GetByIdRequest request, ServerCallContext context)
        {
            var item = database.Items.FindOne(p => p.Id == request.Id);
            if (item is null)
                return await Task.FromResult(new GetByIdResponse
                {
                    Status = new ServiceResult
                    {
                        Success = false,
                        Message = "not found!",
                    },
                });
            return await Task.FromResult(new GetByIdResponse
            {
                Status = new ServiceResult
                {
                    Success = true,
                    Message = "success.",
                },
                Item = item,
            });
        }

        public override async Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {
            // Data Validation
            request.Item.Id = new Random().Next(1000, 9999);       
            var item = database.Items.Insert(request.Item);
            return await Task.FromResult(new CreateResponse
            {
                Status = new ServiceResult
                {
                    Success = true,
                    Message = "success.",
                },
                Item = database.Items.FindOne(p => p.Id == request.Item.Id),
            });
        }

        public override async Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
        {
            bool item = database.Items.Update(request.Item);
            if (!item)
                return await Task.FromResult(new UpdateResponse
                {
                    Status = new ServiceResult
                    {
                        Success = false,
                        Message = "not found!",
                    },
                });
            return await Task.FromResult(new UpdateResponse
            {
                Status = new ServiceResult
                {
                    Success = true,
                    Message = "success.",
                },
                Item = request.Item,
            });
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            int result = database.Items.DeleteMany(p => p.Id == request.Id);
            if (result == 0)
                return await Task.FromResult(new DeleteResponse
                {
                    Status = new ServiceResult
                    {
                        Success = false,
                        Message = "not found!",
                    },
                });
            return await Task.FromResult(new DeleteResponse
            {
                Status = new ServiceResult
                {
                    Success = true,
                    Message = "success.",
                },
            });
        }
    }
}