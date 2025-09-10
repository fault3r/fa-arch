using System;
using GraphqlService.Api.Domain.Entities;

namespace GraphqlService.Api.Infrastructure.Repositories
{
    public class ItemRepository
    {
        private readonly IList<Item> collection;
        
        private int nextId = 6;

        public ItemRepository()
        {
            collection = [
                new Item{Id = 1, Name = "Narsil"},
                new Item{Id = 2, Name = "Palantir"},
                new Item{Id = 3, Name = "Nenya"},
                new Item{Id = 4, Name = "The One Ring"},
                new Item{Id = 5, Name = "Sting"},
            ];
        }

        public IEnumerable<Item> GetAll()
        {
            return collection;
        }

        public Item? GetById(int id)
        {
            return collection.FirstOrDefault(p => p.Id == id);
        }

        public Item? Create(string name)
        {
            collection.Add(new Item { Id = nextId++, Name = name });
            return collection.FirstOrDefault(p => p.Id == nextId - 1);
        }

        public Item? Update(int id, string name)
        {
            var item = collection.FirstOrDefault(p => p.Id == id);
            if (item is null)
                return null;
            item.Name = name;
            return collection.FirstOrDefault(p => p.Id == id);
        }

        public bool Delete(int id)
        {
            var item = collection.FirstOrDefault(p => p.Id == id);
            if (item is null)
                return false;
            return collection.Remove(item);
        }
    }
}