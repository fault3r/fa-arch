using System;

namespace faApi.Api.DTOs
{
    public record AddBookDto
    {
        public required string Title { get; init; }

        public required string Author { get; init; }

        public int Year { get; init; }
    }
}