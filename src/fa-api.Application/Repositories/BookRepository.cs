using System;
using fa_api.Application.Interfaces;
using fa_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fa_api.Application.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ISqlDbContext _sqlDbContext;

        public BookRepository(ISqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<Book?> GetBook(int id)
        {
            var book = await _sqlDbContext.Books.FirstOrDefaultAsync(p => p.Id == id);
            return book;
        }
    }
}