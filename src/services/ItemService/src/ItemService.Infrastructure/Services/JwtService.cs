using System;

namespace ItemService.Infrastructure.Services
{
    public class JwtService
    {
        private readonly HttpClient httpClient;

        public JwtService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("JwtHttpClient");

        }
        
    }
}