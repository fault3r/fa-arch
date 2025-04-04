using AccountService.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;   
        }   

        [Route("Hello")]
        [HttpPost]
        public async Task<IActionResult> Hello([FromBody]HelloCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}
