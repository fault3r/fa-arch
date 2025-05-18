using fa_api.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fa_api.Api.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/ver{version:apiVersion}/Book")]
    [Route("api/Book")]
    public class BookV2Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookV2Controller(IMediator mediator)
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
            {
                book.Title += " --version2";
                return Ok(book);
            }
        }
    }
}
