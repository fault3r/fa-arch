
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FaMicroservice.Api.Controllers.BaseController
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator _mediator = mediator;
    }
}
