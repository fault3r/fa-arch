using System;

namespace AccountService.Domain.Entities
{
    public class Account : BaseEntity
    {
        public required string FullName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }   
    }
}