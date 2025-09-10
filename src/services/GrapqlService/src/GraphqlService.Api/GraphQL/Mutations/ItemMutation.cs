using System;
using GraphqlService.Api.Domain.Entities;
using GraphqlService.Api.Infrastructure.Repositories;

namespace GraphqlService.Api.GraphQL.Mutations
{
    public class ItemMutation
    {
        public Item? Create([Service] ItemRepository itemRepository, string name) =>
            itemRepository.Create(name);

        public Item? Update([Service] ItemRepository itemRepository, int id, string name) =>
            itemRepository.Update(id, name);

        public bool Delete([Service] ItemRepository itemRepository, int id) =>
            itemRepository.Delete(id);
    }
}