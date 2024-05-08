using System.Security.Claims;
using System.Security.Principal;
namespace ShopMicroService.Products.Application.Utilities.Extensions;

public static class UserExtensions
{
    public static ulong GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var data = claimsPrincipal.Claims.FirstOrDefault(s => s.Type == "UserId");

        return ulong.Parse(data.Value);
    }

    public static ulong GetUserId(this IPrincipal principal)
    {
        var user = (ClaimsPrincipal)principal;

        return user.GetUserId();
    }
}
