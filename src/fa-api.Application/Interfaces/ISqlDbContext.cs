using System;
using fa_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fa_api.Application.Interfaces
{
    public interface ISqlDbContext
    {
        DbSet<Book> Books { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}