using System;
using faApi.Domain.Entities;
using faApi.Domain.Interfaces;
using faApi.Infrastructure.Data.Contexts;
using faApi.Infrastructure.Data.Contexts.Documents;
using MongoDB.Driver;

namespace faApi.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDbContext _mongoDbContext;

        public BookRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var books = await _mongoDbContext.BooksCollection.Find(p => true).ToListAsync();
            return books.Select(r => new Book
            {
                Id = r.Id.ToString(),
                Title = r.Title,
                Author = r.Author,
                Year = r.Year,
            });
        }
        
    }
}