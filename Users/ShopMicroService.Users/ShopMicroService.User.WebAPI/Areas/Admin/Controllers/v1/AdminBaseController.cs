using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMicroService.User.WebAPI.Filter;

namespace ShopMicroService.User.WebAPI.Areas.Admin.Controllers.v1;

[ApiController]
[CatchExceptionFilter]
[Authorize]

public class AdminBaseController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}