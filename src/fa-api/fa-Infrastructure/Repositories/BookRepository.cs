using System;
using System.Data.Common;
using faApi.Domain.Entities;
using faApi.Domain.Interfaces;
using faApi.Infrastructure.Data.Contexts;
using faApi.Infrastructure.Data.Contexts.Documents;
using MongoDB.Driver;

// methods works with entity dtos here 
namespace faApi.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDbContext _mongoDbContext;

        public BookRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<Book> GetBook(string id)
        {           
            var dbook = await _mongoDbContext.BooksCollection.Find(p => p.Id.ToString() == id).FirstOrDefaultAsync();
            var book = new Book
            {
                Id = dbook.Id.ToString(),
                Title = dbook.Title,
                Author = dbook.Author,
                Year = dbook.Year,
            };
            return book;
        }

        public async Task<Book> AddBook(Book book)
        {
            var dbook = new BookDocument
            {
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            };
            await _mongoDbContext.BooksCollection.InsertOneAsync(dbook);
            book.Id = dbook.Id.ToString();
            return book;
        }
    }
}