using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Domain.DTOs
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