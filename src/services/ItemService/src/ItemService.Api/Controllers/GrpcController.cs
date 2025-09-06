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
            var items = await grpcService.GetAllAsync();
            return Ok(items);
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery] int id)
        {
            var item = await grpcService.GetByIdAsync(id);
            return Ok(item);

        }
    }
}
