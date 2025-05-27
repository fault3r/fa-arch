using System;
using faApi.Domain.Entities;

namespace faApi.Domain.Interfaces
{
    public interface IBookRepaository
    {
        Task<IEnumerable<Book>> GetAll();

    }
}