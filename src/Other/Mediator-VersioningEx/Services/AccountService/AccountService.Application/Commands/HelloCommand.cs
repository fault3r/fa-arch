using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AccountService.Application.Commands
{
    public class HelloCommand : IRequest<string>
    {
        [Required]
        public required string FullName { get; set; }
    }
}