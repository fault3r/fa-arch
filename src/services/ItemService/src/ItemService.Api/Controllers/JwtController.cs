using ItemService.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JwtController(JwtService jwtService) : ControllerBase
    {

        private readonly JwtService jwtService = jwtService;

        [Route("{uname}")]
        [HttpGet]
        public async Task<ActionResult> Jwt([FromRoute] string uname)
        {
            var token = await jwtService.GenerateToken(uname);
            return Ok(new { token });
        }

        [Route("validate/{token}")]
        [HttpGet]
        public async Task<ActionResult> Validate([FromRoute] string token)
        {
            var status = await jwtService.ValidateToken(token);
            return Ok(new { status });
        }
    }
}
