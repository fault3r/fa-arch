using System;
using MediatR;

namespace AccountService.Application.Commands.Handlers
{
    public class HelloCommandHandler : IRequestHandler<HelloCommand, string>
    {
        public async Task<string> Handle(HelloCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult($"hello {request.FullName}.. ;0");
        }
    }
}