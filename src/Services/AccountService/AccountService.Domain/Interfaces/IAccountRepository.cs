using System;

namespace AccountService.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> GetTrue();
        
    }
}