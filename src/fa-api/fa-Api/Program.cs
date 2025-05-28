using faApi.Application.Handlers.Commands;
using faApi.Application.Handlers.Queries;
using faApi.Application.Interfaces;
using faApi.Application.Services;
using faApi.Domain.Interfaces;
using faApi.Infrastructure.Configurations;
using faApi.Infrastructure.Data.Contexts;
using faApi.Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddMediatR(typeof(AddBookCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(GetBookQueryHandler).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
