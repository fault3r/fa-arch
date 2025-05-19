using System;

namespace fa_api.Domain.Entities
{
    public record Book
    {
        public int Id { get; init; }

        public required string Title { get; init; }

        public required string Author { get; init; }
    }
}