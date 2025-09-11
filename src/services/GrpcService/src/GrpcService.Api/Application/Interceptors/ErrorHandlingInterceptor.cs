using System;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace GrpcService.Api.Application.Interceptors
{
    public class ErrorHandlingInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"*Error: {ex.Message}");
                throw new RpcException(
                    new Status(StatusCode.Internal, "Internal Server Error!"));
            }      
        }
    }
}