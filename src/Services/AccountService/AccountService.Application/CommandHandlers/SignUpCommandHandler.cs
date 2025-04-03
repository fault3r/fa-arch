using System;
using AccountService.Application.Commands;
using AccountService.Domain.Interfaces;
using MediatR;

namespace AccountService.Application.CommandHandlers
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, bool>
    {
        private readonly IAccountRepository _accountRepository;
        
        public SignUpCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        public async Task<bool> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetTrue();
        }
    }
}