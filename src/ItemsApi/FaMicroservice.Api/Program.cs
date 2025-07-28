using FaMicroservice.Infrastructure.Configurations;
using FaMicroservice.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<MongodbSettings>(builder.Configuration.GetSection(nameof(MongodbSettings)));
builder.Services.AddScoped<MongodbContext>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

