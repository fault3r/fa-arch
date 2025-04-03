using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AccountService.Application.Commands
{
    public record SignUpCommand : IRequest<bool>
    {
        public required string FullName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }  
        
        public required string ConfirmPassword { get; set; }  
    }
}