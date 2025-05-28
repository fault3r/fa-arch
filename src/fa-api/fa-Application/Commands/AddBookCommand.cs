using System;
using faApi.Application.DTOs;
using MediatR;

namespace faApi.Application.Commands
{
    public class AddBookCommand : IRequest<BookDto>
    {
        public required string Title { get; set; }

        public required string Author { get; set; }

        public int Year { get; set; }
    }
}