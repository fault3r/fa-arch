using fa_api.Application.Interfaces;
using fa_api.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ISqlDbContext, SqlDbContext>();
builder.Services.AddDbContext<SqlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabase"));
});

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
