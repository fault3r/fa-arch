using System;
using faApi.Domain.Entities;

namespace faApi.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBook(string id);

        Task<Book> AddBook(Book book);
    }
}