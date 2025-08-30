using JwtService.Api.JwtAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JwtService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JwtController(IOptions<JwtSettings> settings) : ControllerBase
    {

        private readonly JwtSettings settings = settings.Value;

        [HttpGet]
        public ActionResult Get([FromQuery] string name)
        {
            var token = JwtToken.Generate(name, settings);
            return Ok(new { Token = token });
        }
    }
}
