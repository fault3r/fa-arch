using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AccountService.Application.Commands
{
    public record SignUpCommand : IRequest<bool>
    {
        [Required(ErrorMessage = "this is require!")]
        public required string Name { get; set; }
    }
}