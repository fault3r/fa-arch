using System;
using fa_api.Domain.Entities;

namespace fa_api.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetBook(int id);
    }
}