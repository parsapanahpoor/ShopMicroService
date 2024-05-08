using ShopMicroService.User.Domain.Entities.Account;
using ShopMicroService.User.Domain.IRepositories.User;
namespace ShopMicroService.User.Infrastructure.Repositories.User;

public class UserCommandRepository : CommandGenericRepository<ShopMicroService.User.Domain.Entities.Account.User>, IUserCommandRepository
{
    #region Ctor

    private readonly ShopMicroServiceUserDbContext _context;

    public UserCommandRepository(ShopMicroServiceUserDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public void Update_SMSCode(SmsCode smsCode)
    {
        _context.SmsCodes.Update(smsCode);
    }

    public async Task Add_UserToken(UserToken userToken, CancellationToken cancellationToken)
    {
        await _context.UserTokens.AddAsync(userToken);
    }

    public async Task Add_SMSCode(SmsCode smsCode, CancellationToken cancellationToken)
    {
        await _context.SmsCodes.AddAsync(smsCode);
    }

    public void Delete_UserToken(UserToken userToken)
    {
        _context.UserTokens.Remove(userToken);
    }

    public void DeleteRange_UserTokens(List<UserToken> userTokens)
    {
        _context.UserTokens.RemoveRange(userTokens);
    }
}
