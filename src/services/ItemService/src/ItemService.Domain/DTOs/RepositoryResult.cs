using System;
using ItemService.Domain.Entities;

namespace ItemService.Domain.DTOs
{
    public class RepositoryResult
    {
        public RepositoryResultStatus Status = RepositoryResultStatus.None;

        public IEnumerable<Item> Items { get; set; } = [];
    }

    public enum RepositoryResultStatus
    {
        None,
        Success,
        InvalidId,
        NotFound,
    }
}