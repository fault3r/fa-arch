using System;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Handlers.Commands;
using ItemService.Application.MediatR.Handlers.Queries;
using ItemService.Application.Services;
using ItemService.Domain.Interfaces;
using ItemService.Infrastructure.Configurations;
using ItemService.Infrastructure.Data.Contexts;
using ItemService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ItemService.Api.Common
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<MongodbSettings>(configuration.GetSection(nameof(MongodbSettings)));
            services.AddScoped<MongodbContext>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IItemsService, ItemsService>();
            return services;
        }

        public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            return services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(GetAllQueryHandler).Assembly);
                options.RegisterServicesFromAssembly(typeof(GetByIdQueryHandler).Assembly);
                options.RegisterServicesFromAssembly(typeof(CreateCommandHandler).Assembly);
                options.RegisterServicesFromAssembly(typeof(UpdateCommandHandler).Assembly);
                options.RegisterServicesFromAssembly(typeof(DeleteCommandHandler).Assembly);
            });
        }

        public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
        {
            return services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader()
                        // new QueryStringApiVersionReader("v"),
                        // new HeaderApiVersionReader("api-version"));
                );
            });
        }
    }
}