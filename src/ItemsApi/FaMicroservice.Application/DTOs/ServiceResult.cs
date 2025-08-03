using System;

namespace FaMicroservice.Application.DTOs
{
    public record ServiceResult
    {
        public RepositoryResultStatus Status = RepositoryResultStatus.None;

        public IEnumerable<Item> Items { get; set; } = [];
    }
}