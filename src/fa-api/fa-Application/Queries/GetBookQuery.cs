using System;
using faApi.Application.DTOs;
using MediatR;

namespace faApi.Application.Queries
{
    public class GetBookQuery : IRequest<BookDto>
    {
        public string? Id { get; set; }        
    }
}