using System;
using FaMicroservice.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Api.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController(IItemsService itemsService) : ControllerBase
    {
        private readonly IItemsService _itemsService = itemsService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllAsync()
        {
            var items = await _itemsService.GetAllAsync();
            return Ok(items);
            /*
                Get: No parameters
                Return:
                    Status Code: 200 OK
                    Body: JSON array of all records
            */
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(string id)
        {
            var item = await _itemsService.GetByIdAsync(id);
            if (item is null)
                return NotFound();
            return Ok(item);
            /*
                Get: Id
                Return:
                    Status Code:
                        200 OK (if found)
                        404 Not Found (if not found)
                    Body: JSON object of the record if found
            */
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateAsync([FromBody] CreateItemDto item)
        {
            if (item is null)
                return BadRequest();
            var newItem = await _itemsService.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { newItem?.Id, newItem }, newItem);
            /*
                Get: No parameters
                Return:
                    Status Code: 201 Created
                    Body: JSON object of the created record, including its unique identifier.
            */
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateAsync(string id, [FromBody] UpdateItemDto item)
        {
            if (item is null)
                return BadRequest();
            var uItem = await _itemsService.UpdateAsync(id, item);
            if (uItem is null)
                return NotFound();
            return Ok(uItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var result = await _itemsService.DeleteAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
