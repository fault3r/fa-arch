using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {

    }
}
