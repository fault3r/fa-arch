using fa_api.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fa_api.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/ver{version:apiVersion}/Book")]
    [Route("api/Book")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetBookRequest { BookId = id };
            var book = await _mediator.Send(request);
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }
    }
}
