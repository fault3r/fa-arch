using System;
using FaMicroservice.Domain.Entities;

namespace FaMicroservice.Domain.DTOs
{
    public class RepositoryResult
    {
        public RepositoryResultStatus Status;

        public IEnumerable<Item> Items { get; set; } = [];
    }

    public enum RepositoryResultStatus
    {
        Success,
        InvalidId,
        NotFound,
    }
}