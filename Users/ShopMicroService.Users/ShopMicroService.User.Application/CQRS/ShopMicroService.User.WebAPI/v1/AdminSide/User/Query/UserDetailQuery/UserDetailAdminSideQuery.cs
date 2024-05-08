using ShopMicroService.User.Domain.DTO.AdminSide.User;

namespace ShopMicroService.User.Application.CQRS.APIClient.v1.AdminSide.User.Query.UserDetailQuery;

public record UserDetailAdminSideQuery : IRequest<UserDetailAdminSideDTO>
{
    #region proeprties

    public ulong UserId { get; set; }

    #endregion
}
