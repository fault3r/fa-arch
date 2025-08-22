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
    [Route("api/v1/items")]
    public class ItemsV1Controller(IMediator mediator) : ItemsController(mediator)
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllQuery());
            return Ok(result.Items);
        }

        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ActionResult<ItemDto?>> CreateAsync([FromBody] CreateItemDto item)
        {
            var result = await _mediator.Send(new CreateCommand { Item = item });
            if (result.Status == ServiceResultStatus.BadRequest)
                return BadRequest();
            var newItem = result.Items.FirstOrDefault();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newItem?.Id }, newItem);
        }

        [MapToApiVersion("1.0")]
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
        
        [MapToApiVersion("1.0")]
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
