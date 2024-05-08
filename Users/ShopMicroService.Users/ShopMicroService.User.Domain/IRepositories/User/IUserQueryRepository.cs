using ShopMicroService.User.Domain.DTO.AdminSide.User;
using ShopMicroService.User.Domain.Entities.Account;

namespace ShopMicroService.User.Domain.IRepositories.User;

public interface IUserQueryRepository
{
    #region General Methods

    Task<List<UserToken>> GetList_UserToken_ByUserId(ulong userId,
                                                     CancellationToken cancellationToken);

    Task<UserToken?> GetUserToken_ByUserTokenId(ulong userTokenId,
                                                CancellationToken cancellation);

    Task<UserToken?> Get_UserToken_ByRefreshToken(string refreshToken);

    Task<SmsCode?> GetSMSCode_ByMobileAndCode(string mobile, string code);

    Task<bool> IsMobileExist(string mobile, CancellationToken cancellation);

    Task<bool> IsUserActive(string mobile , CancellationToken cancellation);

    Task<Domain.Entities.Account.User?> GetUserByMobile(string mobile, CancellationToken cancellation);

    Task<Domain.Entities.Account.User> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);

    #endregion

    #region Site Side

    Task<bool> CheckIsExist_UserToken(string hashedToken);

    #endregion

    #region Admin Side 

    Task<FilterUsersDTO> FilterUsers(FilterUsersDTO filter, CancellationToken cancellation);

    #endregion
}
