using System;
using GrpcService.Protos;
using Grpc.Net.Client;
using static GrpcService.Protos.GrpcService;

namespace ItemService.Infrastructure.Services
{
    public record GrpcItem(int Id, string Name);

    public class GrpcService
    {
        private readonly GrpcServiceClient grpcClient;

        public GrpcService()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5007");
            grpcClient = new GrpcServiceClient(channel);
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

        public async Task<GrpcItem?> CreateAsync(string name)
        {
            var response = await grpcClient.CreateAsync(new CreateRequest
            {
                Item = new Item { Name = name },
            });
            if (!response.Status.Success)
                return null;
            return new GrpcItem(response.Item.Id, response.Item.Name);
        }

        public async Task<GrpcItem?> UpdateAsync(int id, string name)
        {
            var response = await grpcClient.UpdateAsync(new UpdateRequest
            {
                Item = new Item { Id = id, Name = name },
            });
            if (!response.Status.Success)
                return null;
            return new GrpcItem(id, name);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await grpcClient.DeleteAsync(new DeleteRequest { Id = id });
            if (!response.Status.Success)
                return false;
            return true;
        }
    }
}