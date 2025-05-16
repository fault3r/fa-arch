using fa_api.Application.Handlers;
using fa_api.Application.Interfaces;
using fa_api.Application.Repositories;
using fa_api.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ISqlDbContext, SqlDbContext>();
builder.Services.AddDbContext<SqlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabase"));
});

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddMediatR(typeof(GetBookHandler).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//pipeline
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
