using System;
using faApi.Domain.Entities;

namespace faApi.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();

    }
}