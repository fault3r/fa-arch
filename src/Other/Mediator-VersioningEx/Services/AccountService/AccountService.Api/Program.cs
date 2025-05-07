using AccountService.Application.Commands.Handlers;
using AccountService.Infrastructure.Configurations;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioningConfiguration();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Account", Version = "v1" });
        c.SwaggerDoc("v2", new OpenApiInfo { Title = "Account", Version = "v2" });
});

builder.Services.AddMediatR(typeof(HelloCommandHandler).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Account v2");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
