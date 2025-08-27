using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Api.Controllers
{
    [Authorize(Policy = "requireAccount")]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {        
        [HttpGet]
        public IActionResult Jwt()
        {
            return Ok(new { status = "access granted." });
        }
        
    }
}
