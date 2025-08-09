using System;
using ItemService.Api.Controllers.BaseController;
using ItemService.Application.MediatR.Commands;
using ItemService.Application.MediatR.DTOs;
using ItemService.Application.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static ItemService.Application.DTOs.ServiceResult;

namespace ItemService.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/items")]
    public class ItemsV1Controller(IMediator mediator) : ItemsController(mediator)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllQuery());
            return Ok(result.Items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ItemDto?>> GetByIdAsync(string id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });
            if (result.Status == ServiceResultStatus.BadRequest)
                return BadRequest();
            else if (result.Status == ServiceResultStatus.NotFound)
                return NotFound();
            return Ok(result.Items.FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto?>> CreateAsync([FromBody] CreateItemDto item)
        {
            var result = await _mediator.Send(new CreateCommand { Item = item });
            if (result.Status == ServiceResultStatus.BadRequest)
                return BadRequest();
            var newItem = result.Items.FirstOrDefault();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newItem?.Id }, newItem);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ItemDto?>> UpdateAsync(string id, [FromBody] UpdateItemDto item)
        {
            var result = await _mediator.Send(new UpdateCommand { Id = id, Item = item });
            if (result.Status == ServiceResultStatus.BadRequest)
                return BadRequest();
            else if (result.Status == ServiceResultStatus.NotFound)
                return NotFound();
            var updatedItem = result.Items.FirstOrDefault();
            return Ok(updatedItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var result = await _mediator.Send(new DeleteCommand { Id = id });
            if (result.Status == ServiceResultStatus.BadRequest)
                return BadRequest();
            else if (result.Status == ServiceResultStatus.NotFound)
                return NotFound();
            return NoContent();
        }
    }
}
