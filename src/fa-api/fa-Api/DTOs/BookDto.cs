using System;

namespace faApi.Api.DTOs
{
    public record BookDto
    {
        public required string Id { get; init; }

        public required string Title { get; init; }

        public required string Author { get; init; }

        public int Year { get; init; }
    }
}