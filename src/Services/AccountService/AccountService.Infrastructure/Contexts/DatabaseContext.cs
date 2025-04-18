using System;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) 
        {
        
        }

        protected override OnConfiguration(DbOptionsBuilder builder)
        {
            builder.Entities<Account>.hasKey(p => p.Id);
        }
    }
}
