namespace ShopMicroService.User.Domain.Entities.Account;

public sealed class User : BaseEntities<ulong>
{
    #region properties

    public string Username { get; set; }

    public string Mobile { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsActive { get; set; }

    public string? Avatar { get; set; }

    #endregion
}
