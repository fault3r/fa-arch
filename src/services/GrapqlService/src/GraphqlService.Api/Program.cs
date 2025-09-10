using GraphqlService.Api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<GraphqlCalc>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGraphQL("/api/graphql");

app.Run();