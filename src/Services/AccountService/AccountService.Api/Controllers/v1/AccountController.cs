using AccountService.Application.Commands;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public virtual async Task<IActionResult> Hello([FromBody]HelloCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}
