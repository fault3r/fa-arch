using System;
using fa_api.Application.Interfaces;
using fa_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fa_api.Infrastructure.Contexts;

public class SqlDbContext : DbContext, ISqlDbContext
{
    public SqlDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>().HasKey(p => p.Id);
    }
}
