using System;

namespace faApi.Domain.Entities
{
    public class Book
    {
        public string? Id { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public int Year { get; set; }                
    }
}