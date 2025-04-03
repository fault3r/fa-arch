using System;
using AccountService.Application.Commands;
using MediatR;

namespace AccountService.Application.CommandHandlers
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, bool>
    {
        public async Task<bool> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}