using ShopMicroService.User.WebAPI.HttpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ShopMicroService.User.WebAPI.Areas.Admin.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Admin/[controller]")]

public class HomeController : AdminBaseController
{
    #region Admin Dashboard

    [HttpGet("admin-dashboard")]
	public async Task<IActionResult> AdminDashboard(CancellationToken cancellationToken)
	{
		return Ok(JsonResponseStatus.Success(null , "Wellcome to admin dashboard"));
	}

	#endregion
}
