using System;
using faApi.Application.DTOs;
using faApi.Application.Interfaces;
using faApi.Application.Queries;
using MediatR;

namespace faApi.Application.Handlers.Queries
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        
        private readonly IBookService _bookService;

        public GetBookQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBook(request.Id);
            return book;
        }
    }
}