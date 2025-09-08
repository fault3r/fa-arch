using ItemService.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController(GrpcService grpcService) : ControllerBase
    {
        private readonly GrpcService grpcService = grpcService;

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok();
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery] int id)
        {
            return Ok();
        }
    }
}
