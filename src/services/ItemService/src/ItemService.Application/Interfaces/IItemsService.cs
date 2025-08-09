using System;
using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.MediatR.DTOs;

namespace FaMicroservice.Application.Interfaces
{
    public interface IItemsService
    {
        Task<ServiceResult> GetAllAsync();

        Task<ServiceResult> GetByIdAsync(string id);

        Task<ServiceResult> CreateAsync(CreateItemDto item);

        Task<ServiceResult> UpdateAsync(string id, UpdateItemDto item);

        Task<ServiceResult> DeleteAsync(string id);
    }
}