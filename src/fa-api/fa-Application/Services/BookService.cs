using System;
using faApi.Application.DTOs;
using faApi.Application.Interfaces;
using faApi.Domain.Entities;
using faApi.Domain.Interfaces;
using faApi.Infrastructure.Repositories;

namespace faApi.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> GetBook(string id)
        {
            var book = await _bookRepository.GetBook(id);
            return new BookDto
            {
                Id = book.Id.ToString(),
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            };
        }

        public async Task<BookDto> AddBook(AddBookDto book)
        {
            var tbook = await _bookRepository.AddBook(new Book
            {
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            });
            return new BookDto
            {
                Id = tbook.Id,
                Title = tbook.Title,
                Author = tbook.Author,
                Year = tbook.Year,
            };
        }
    }
}