using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
       // private ISender _mediator;

        /// <summary>
        /// Mediator sender
        /// </summary>
        //protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
