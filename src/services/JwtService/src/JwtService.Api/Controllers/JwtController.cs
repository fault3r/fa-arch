using JwtService.Api.JwtAuthentication;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult Get()
        {
            return Ok(new { description = "Jwt Service." });
        }

        [Route("/token/{uname}")]
        [HttpGet]
        public ActionResult Token([FromRoute] string uname)
        {
            var token = JwtToken.Generate(uname, settings);
            return Ok(new { token });
        }
        
        [Route("/token")]
        [Authorize(Policy = "requireAccount")]
        [HttpGet]
        public ActionResult Validate()
        {
            return Ok(new { status = "access granted." });
        }
    }
}
