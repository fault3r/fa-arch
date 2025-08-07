
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static FaMicroservice.Application.DTOs.ItemDTOs;

namespace FaMicroservice.Api.Controllers.BaseController
{
    [ApiController]
    public class ItemsController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator _mediator = mediator;
    }
}
