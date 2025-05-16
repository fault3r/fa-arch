using System;
using fa_api.Application.Requests;
using fa_api.Domain.Entities;
using MediatR;

namespace fa_api.Application.Handlers
{
    public class GetBookHandler : IRequestHandler<GetBookRequest, Book>
    {
        public Task<Book> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}