using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopMicroService.User.WebAPI.Filter;

namespace ShopMicroService.User.WebAPI.Controllers.v1;

[ApiController]
[CatchExceptionFilter]

public class SiteBaseController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
