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
        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            return await _itemsService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(string id)
        {
            var item = await _itemsService.GetByIdAsync(id);
            if (item is null)
                return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateAsync([FromBody] CreateItemDto item)
        {
            if (item is null)
                return BadRequest();
            var nItem = await _itemsService.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = nItem.Id }, nItem);
        }
    }
}
