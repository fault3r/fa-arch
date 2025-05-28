using System;
using faApi.Application.DTOs;

namespace faApi.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetBook(string id);

        Task<BookDto> AddBook(AddBookDto book);

    }
}