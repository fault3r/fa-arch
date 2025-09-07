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
    }
}