using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Filters;

namespace WebUI.Controllers
{
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private ISender? _sender;
        protected ISender _mediator => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
