using System;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Application.DTOs
{
    public class ServiceResult
    {
        public ServiceResultStatus Status = ServiceResultStatus.None;

        public IEnumerable<ItemDto> Items { get; set; } = [];

        public enum ServiceResultStatus
        {
            None,
            Ok,
            BadRequest,
            NotFound,
            Created,
            NoContent,
        }

    }
}