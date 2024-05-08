using ShopMicroService.User.Domain.DTO.Common;

namespace ShopMicroService.User.Domain.DTO.AdminSide.User;

public class FilterUsersDTO : BasePaging<Entities.Account.User>
{
    #region properties

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    #endregion
}
