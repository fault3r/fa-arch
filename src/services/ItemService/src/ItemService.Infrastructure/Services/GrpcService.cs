using System;
using Grpc.Net.Client;
using ItemService.Infrastructure.Protos;
using static ItemService.Infrastructure.Protos.BasketService;

namespace ItemService.Infrastructure.Services
{
    public record ItemGrpc(int Id, string Name);

    public class GrpcService
    {
        private readonly BasketServiceClient client;

        public GrpcService()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5007");
            client = new BasketServiceClient(channel);
        }

        public async Task<IEnumerable<ItemGrpc>> GetAllAsync()
        {
            var items = await client.GetAllAsync(new GetAllRequest());
            return items.Items_.Select(r => new ItemGrpc(r.Id, r.Name));
        }

        public async Task<ItemGrpc> GetByIdAsync(int id)
        {
            var item = await client.GetByIdAsync(new GetByIdRequest { Id = id });
            return new ItemGrpc(item.Id, item.Name);
        }

        public async Task<ItemGrpc> CreateAsync(int id, string name)
        {
            var item = await client.CreateAsync(new CreateRequest
            {
                Item = new Item
                {
                    Id = id,
                    Name = name,
                }
            });
            return new ItemGrpc(item.Id, item.Name);
        }

        public async Task<ItemGrpc> UpdateAsync(int id, string name)
        {
            var item = await client.UpdateAsync(new UpdateRequest
            {
                Item = new Item
                {
                    Id = id,
                    Name = name,
                }
            });
            return new ItemGrpc(item.Id, item.Name);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await client.DeleteAsync(new DeleteRequest { Id = id });
            return result.Success;
        }
    }
}