using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JwtService.Api.JwtAuthentication
{
    public static class JwtToken
    {
        public static string Generate(string name, JwtSettings settings)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, "account"),
                new Claim("Project","fa-arch"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: settings.Issuer,
                audience: settings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}