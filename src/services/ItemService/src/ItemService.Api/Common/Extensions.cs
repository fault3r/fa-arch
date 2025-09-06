using System;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Handlers.Commands;
using ItemService.Application.MediatR.Handlers.Queries;
using ItemService.Application.Services;
using ItemService.Domain.Interfaces;
using ItemService.Infrastructure.Configurations;
using ItemService.Infrastructure.Data.Contexts;
using ItemService.Infrastructure.Repositories;
using ItemService.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Polly;
using Polly.Extensions.Http;

namespace ItemService.Api.Common
{
    public static class Extensions
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<MongodbSettings>(configuration.GetSection(nameof(MongodbSettings)));
            services.AddScoped(typeof(MongodbContext), provider =>
            {
                var settings = provider.GetRequiredService<IOptions<MongodbSettings>>().Value;
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);
                return new MongodbContext(database, settings.CollectionName);
            });
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<JwtService>();
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

        public static IServiceCollection AddJwtHttpConfiguration(this IServiceCollection services, IConfigurationSection settings)
        {
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(5));
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, attemp => TimeSpan.FromSeconds(Math.Pow(2, attemp)));
            var circuitBreakerPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(20));
            services.AddHttpClient("JwtHttpClient", client =>
            {
                client.BaseAddress = new Uri(settings["Uri"] ?? throw new Exception());
            })
                .AddPolicyHandler(retryPolicy);
            // .AddPolicyHandler(timeoutPolicy)
            // .AddPolicyHandler(circuitBreakerPolicy)
            return services;
        }


        public static IServiceCollection AddGrpcConfiguration(this IServiceCollection services)
        {
            services.AddScoped<GrpcService>();
            return services;
        }
    }
}