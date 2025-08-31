using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

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
            try
            {
                var response = await httpClient.GetAsync($"token/{uname}");
                var token = await response.Content.ReadFromJsonAsync<JwtToken>();
                return token.Token;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> ValidateToken(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync("token");
            var result = await response.Content.ReadFromJsonAsync<JwtStatus>();
            return result.Status;
        }
    }

    public record JwtToken(string Token);
    public record JwtStatus(string Status);
}