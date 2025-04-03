using AccountService.Api.Controllers.BaseController;
using AccountService.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : IBaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUpCommand signUpCommand)
        {
            var res = await _mediator.Send(signUpCommand);
            return Ok(res);
        }
    }
}
