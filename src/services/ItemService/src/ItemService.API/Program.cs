
using System;
using ItemService.Api.Common;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers(options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    });

    builder.Services.AddApiConfiguration(builder.Configuration);

    builder.Services.AddApiVersioningConfiguration();

    builder.Services.AddMediatRConfiguration();


var app = builder.Build();

    if (app.Environment.IsDevelopment())
        app.UseDeveloperExceptionPage();

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
