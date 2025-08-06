
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
            foreach (var item in result.Items)
            {
                result.Items
            }
            return Ok(result);
        }
    }
}
