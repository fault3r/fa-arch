using System;
using fa_api.Domain.Entities;
using MediatR;

namespace fa_api.Application.Requests
{
    public class GetBookRequest : IRequest<Book>
    {
        public int BookId { get; set; }
    }
}