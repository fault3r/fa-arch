
using GraphqlService.Api.GraphQL.Mutations;
using GraphqlService.Api.GraphQL.Queries;
using GraphqlService.Api.GraphQL.Types;
using GraphqlService.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ItemRepository>();

builder.Services.AddGraphQLServer()
    // .AddAuthorization() to enable authorization support
    .AddType<ItemType>()
    .AddQueryType<ItemQuery>()
    .AddMutationType<ItemMutation>();    

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGraphQL("/graphql");

app.Run();