
using FaMicroservice.Api.Controllers.BaseController;
using FaMicroservice.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Api.Controllers
{
    [ApiVersion("2.0")]
    public class ItemsV2Controller(IMediator mediator) : ItemsController(mediator)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllQuery());
            List<ItemDto> nItems = [];
            foreach (var item in result.Items)
            {
                decimal nPrice = item.Price + 26;
                nItems.Add(item with { Price = nPrice });
            }
            return Ok(nItems);
        }
    }
}
