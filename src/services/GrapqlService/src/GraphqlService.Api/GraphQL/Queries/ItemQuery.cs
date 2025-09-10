using System;
using GraphqlService.Api.Domain.Entities;
using GraphqlService.Api.Infrastructure.Repositories;

namespace GraphqlService.Api.GraphQL.Queries
{
    public class ItemQuery
    {
        public IEnumerable<Item> GetAll([Service] ItemRepository itemRepository) =>
            itemRepository.GetAll();

        public Item? GetById([Service] ItemRepository itemRepository, int id) =>
            itemRepository.GetById(id);
    }
}