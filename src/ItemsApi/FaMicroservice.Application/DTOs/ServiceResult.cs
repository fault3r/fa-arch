using System;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Application.DTOs
{
    public class ServiceResult
    {
        public ServiceResultStatus Status;

        public IEnumerable<ItemDto> Items { get; set; } = [];

        public enum ServiceResultStatus
        {
            Ok,
            BadRequest,
            NotFound,
            Created,
            NoContent,
        }
    }

}