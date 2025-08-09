using System;
using ItemService.Application.DTOs;
using ItemService.Application.MediatR.DTOs;

namespace ItemService.Application.Interfaces
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