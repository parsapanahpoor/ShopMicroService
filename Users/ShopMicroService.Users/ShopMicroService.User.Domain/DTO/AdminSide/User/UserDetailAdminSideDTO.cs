namespace ShopMicroService.User.Domain.DTO.AdminSide.User;

public record UserDetailAdminSideDTO
{
    #region properties

    public ulong UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsActive { get; set; }

    public string? Avatar { get; set; }

    public List<ulong> UserRolesId { get; set; }

    #endregion
}
