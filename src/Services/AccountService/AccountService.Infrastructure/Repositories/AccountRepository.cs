using System;
using AccountService.Domain.Interfaces;

namespace AccountService.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<bool> GetTrue()
        {
            return true;
        }
    }
}