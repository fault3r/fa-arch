using faApi.Application.Commands;
using faApi.Application.Interfaces;
using faApi.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace faApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(string id)
        {
            var request = new GetBookQuery { Id = id };
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}
