using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopMicroService.Products.Presentation.Filter;

namespace ShopMicroService.Products.Presentation.Controllers.v1;

[ApiController]
[CatchExceptionFilter]

public class SiteBaseController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
