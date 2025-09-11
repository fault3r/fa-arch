using System;
using GrpcService.Api.Infrastructure.Data;
using GrpcService.Protos;
using Grpc.Core;
using static GrpcService.Protos.GrpcService;

namespace GrpcService.Api.Application.Services
{
    public class AppGrpcService(LitedbContext database) : GrpcServiceBase
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
            if(items.Any())
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
            request.Item.Id = new Random().Next(1000, 9999);
            if (request.Item.Name == string.Empty)
                request.Item.Name = "no-name";
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
            if (request.Item.Name == string.Empty)
                request.Item.Name = "no-name";
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