using System;
using System.Text.Json;

namespace ItemService.Api.Middlewares
{

    public class AuthMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            if (httpContext.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                httpContext.Response.ContentType = "application/json";
                var status = new { status = "access denied!" };
                await httpContext.Response.WriteAsync(
                    JsonSerializer.Serialize<dynamic>(status));
            }
            else if (httpContext.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                httpContext.Response.ContentType = "application/json";
                var status = new { status = "invalid token!" };
                await httpContext.Response.WriteAsync(
                    JsonSerializer.Serialize<dynamic>(status));
            }
        }
    }

    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}