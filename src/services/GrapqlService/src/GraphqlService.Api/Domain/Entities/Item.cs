using System;

namespace GraphqlService.Api.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}