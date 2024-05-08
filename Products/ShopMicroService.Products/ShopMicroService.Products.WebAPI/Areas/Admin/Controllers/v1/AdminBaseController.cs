using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMicroService.Products.Presentation.Filter;

namespace ShopMicroService.Products.Presentation.Areas.Admin.Controllers.v1;

[ApiController]
[CatchExceptionFilter]

public class AdminBaseController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}