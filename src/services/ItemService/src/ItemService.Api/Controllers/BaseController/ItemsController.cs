
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Api.Controllers.BaseController
{
    [ApiController]
    public class ItemsController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator _mediator = mediator;
    }
}
