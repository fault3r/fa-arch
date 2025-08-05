using FaMicroservice.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/items")]
    public class ItemsV2Controller(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllQuery());
            return Ok(result.Items.Append(new ItemDto("v2", "v2", "v2", 2, DateTime.UtcNow)));
        }
    }
}
