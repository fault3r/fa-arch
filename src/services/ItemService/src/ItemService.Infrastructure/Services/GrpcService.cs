using System;
using BasketService.Protos;
using Grpc.Net.Client;
using static BasketService.Protos.BasketService;

namespace ItemService.Infrastructure.Services
{
    public record GrpcItem(int Id, string Name);

    public class GrpcService
    {
        private readonly BasketServiceClient grpcClient;

        public GrpcService()
        {
            var grpcClient = new BasketServiceClient(
                GrpcChannel.ForAddress("http://localhost:5007"));
        }

        public async Task<IEnumerable<GrpcItem>> GetAllAsync()
        {
            var response = await grpcClient.GetAllAsync(new GetAllRequest());
            return response.Items.Select(r => new GrpcItem(r.Id, r.Name));
        }

        public async Task<GrpcItem?> GetByIdAsync(int id)
        {
            var response = await grpcClient.GetByIdAsync(new GetByIdRequest { Id = id });
            if (!response.Status.Success)
                return null;
            return new GrpcItem(response.Item.Id, response.Item.Name);
        }

        
    }
}