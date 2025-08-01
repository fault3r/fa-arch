using FaMicroservice.Application.DTOs;
using FaMicroservice.Application.Interfaces;
using FaMicroservice.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaMicroservice.Api.Controllers
{
    [ApiController]
    [Route("items")]
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
            var nItem = await _itemsService.CreateAsync(item);
            if (nItem is null)
                return BadRequest();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = nItem.Id }, nItem);
        }
    }
}
