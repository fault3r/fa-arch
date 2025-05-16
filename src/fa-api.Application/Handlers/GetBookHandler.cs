using System;
using fa_api.Application.Interfaces;
using fa_api.Application.Requests;
using fa_api.Domain.Entities;
using MediatR;

namespace fa_api.Application.Handlers
{
    public class GetBookHandler : IRequestHandler<GetBookRequest, Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBook(request.BookId);
            return book;
        }
    }
}