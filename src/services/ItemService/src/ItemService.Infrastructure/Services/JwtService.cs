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

        public async Task<string> GenerateToken(string uname)
        {
            var response = await httpClient.GetAsync($"token/{uname}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}