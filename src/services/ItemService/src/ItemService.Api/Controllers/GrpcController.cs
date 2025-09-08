using ItemService.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController(GrpcService grpcService) : ControllerBase
    {
        private readonly GrpcService grpcService = grpcService;

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var items = await grpcService.GetAllAsync();
            return Ok(items);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetByIdAsync([FromRoute] string id)
        {
            var item = await grpcService.GetByIdAsync(Convert.ToInt32(id));
            return Ok(item);
        }

        [Route("create")]
        [HttpGet]
        public async Task<ActionResult> CreateAsync([FromQuery] string name)
        {
            var item = await grpcService.CreateAsync(name);
            return Ok(item);
        }

        [Route("update")]
        [HttpGet]
        public async Task<ActionResult> UpdateAsync([FromQuery] int id, string name)
        {
            var item = await grpcService.UpdateAsync(id, name);
            return Ok(item);
        }

        [Route("delete")]
        [HttpGet]
        public async Task<ActionResult> DeleteAsync([FromQuery] int id)
        {
            bool item = await grpcService.DeleteAsync(id);
            return Ok(item);
        }

    }
}
