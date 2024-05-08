using ShopMicroService.User.Domain.DTO.AdminSide.User;

namespace ShopMicroService.User.Application.CQRS.APIClient.v1.AdminSide.User.Query;

public record FilterUsersAdminSideQuery : IRequest<FilterUsersDTO>
{
    #region properties

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    #endregion
}
