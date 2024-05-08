using ShopMicroService.User.Domain.Entities.Account;

namespace ShopMicroService.User.Domain.IRepositories.User;

public interface IUserCommandRepository
{
    #region General Methods

    Task AddAsync(Domain.Entities.Account.User user, CancellationToken cancellationToken);

    void Update(Domain.Entities.Account.User user);

    void Update_SMSCode(SmsCode smsCode);

    Task Add_UserToken(UserToken userToken, CancellationToken cancellationToken);

    Task Add_SMSCode(SmsCode smsCode, CancellationToken cancellationToken);

    void Delete_UserToken(UserToken userToken);

    void DeleteRange_UserTokens(List<UserToken> userTokens);

    #endregion
}
