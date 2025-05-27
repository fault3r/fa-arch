using System;
using faApi.Application.DTOs;

namespace faApi.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAll();
    }
}