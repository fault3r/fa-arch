using AccountService.Api.Controllers.v1;
using AccountService.Application.Commands;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : v1.AccountController
    {
        public AccountController(IMediator mediator) : base(mediator){}

        [Route("Hello")]
        [HttpPost]
        public override async Task<IActionResult> Hello([FromBody]HelloCommand command)
        {
            return Ok("Hello User, this is v2.");
        }
    }
}
