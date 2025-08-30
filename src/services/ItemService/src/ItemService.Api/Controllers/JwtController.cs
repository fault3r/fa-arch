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

        [HttpGet]
        public async Task<ActionResult> Jwt()
        {
            var token = await jwtService.GenerateToken("fault3r");
            return Ok(new { token });
        }
    }
}
