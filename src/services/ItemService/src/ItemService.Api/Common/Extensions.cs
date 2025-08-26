using System;
using System.Text;
using ItemService.Application.Interfaces;
using ItemService.Application.MediatR.Handlers.Commands;
using ItemService.Application.MediatR.Handlers.Queries;
using ItemService.Application.Services;
using ItemService.Domain.Interfaces;
using ItemService.Infrastructure.Configurations;
using ItemService.Infrastructure.Data.Contexts;
using ItemService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

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

        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfigurationSection settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {                    
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings["Key"]??"key")),
                        ValidIssuer = settings["Issuer"],
                        ValidAudience = settings["Audience"],
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                    };
                });
            services.AddAuthorization();            
            return services;
        }
    }
}