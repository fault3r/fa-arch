
using FaMicroservice.Api.Controllers.BaseController;
using FaMicroservice.Application.MediatR.DTOs;
using FaMicroservice.Application.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FaMicroservice.Api.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/items")]
    public class ItemsV2Controller(IMediator mediator) : ItemsController(mediator)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllQuery());
            List<ItemDto> newItems = [];
            foreach (var item in result.Items)
            {
                decimal newPrice = item.Price + 26;
                newItems.Add(item with { Price = newPrice });
            }
            return Ok(newItems);
        }
    }
}
