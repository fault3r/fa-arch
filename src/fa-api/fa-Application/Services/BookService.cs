using System;
using faApi.Application.DTOs;
using faApi.Application.Interfaces;
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

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _bookRepository.GetAll();
            return books.Select(r => new BookDto
            {
                Id = r.Id,
                Title = r.Title,
                Author = r.Author,
                Year = r.Year,
            });
        }
        
    }
}