using fa_api.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fa_api.Api.Controllers
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var request = new GetBookRequest{BookId = id};
            var book = await _mediator.Send(request);
            if (book == null)
                return NotFound();
            else
                return  Ok(book);
        }
    }
}
