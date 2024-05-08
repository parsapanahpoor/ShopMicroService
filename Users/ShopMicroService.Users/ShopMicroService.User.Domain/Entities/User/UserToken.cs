namespace ShopMicroService.User.Domain.Entities.Account;

public sealed class UserToken : BaseEntities<ulong>
{
    #region properties

    public ulong UserId { get; set; }

    public string TokenHash { get; set; }

    public string RefreshToken { get; set; }

    public string LastestSignInPlatformName { get; set; }

    public DateTime TokenExpireTime { get; set; }

    public DateTime RefreshTokenExpireTime { get; set; }

    #endregion
}
