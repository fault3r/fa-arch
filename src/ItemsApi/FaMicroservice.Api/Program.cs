
using System;
using FaMicroservice.Application.Handlers.Commands;
using FaMicroservice.Application.Handlers.Queries;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Application.Services;
using FaMicroservice.Domain.Interfaces;
using FaMicroservice.Infrastructure.Configurations;
using FaMicroservice.Infrastructure.Data.Contexts;
using FaMicroservice.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("v"),
        new HeaderApiVersionReader("api-version"));
        // new UrlSegmentApiVersionReader()
        // [Route("api/v{version:apiVersion}/items")]
});

builder.Services.Configure<MongodbSettings>(builder.Configuration.GetSection(nameof(MongodbSettings)));
builder.Services.AddScoped<MongodbContext>();

builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IItemsService, ItemsService>();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(GetAllQueryHandler).Assembly);
    options.RegisterServicesFromAssembly(typeof(GetByIdQueryHandler).Assembly);
    options.RegisterServicesFromAssembly(typeof(CreateCommandHandler).Assembly);
    options.RegisterServicesFromAssembly(typeof(UpdateCommandHandler).Assembly);
    options.RegisterServicesFromAssembly(typeof(DeleteCommandHandler).Assembly);
});

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

