using ShopMicroService.User.Domain.IRepositories.User;
using Microsoft.EntityFrameworkCore;
using ShopMicroService.User.Domain.Entities.Account;
using ShopMicroService.User.Application.Utilities.Security;
using ShopMicroService.User.Domain.DTO.AdminSide.User;
using ShopMicroService.User.Infrastructure.ApplicationDbContext;
namespace ShopMicroService.User.Infrastructure.Repositories.User;

public class UserQueryRepository : QueryGenericRepository<ShopMicroService.User.Domain.Entities.Account.User>, IUserQueryRepository
{
    #region Ctor

    private readonly ShopMicroServiceUserDbContext _context;

    public UserQueryRepository(ShopMicroServiceUserDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region General Methods

    public async Task<List<UserToken>> GetList_UserToken_ByUserId(ulong userId,
                                                                  CancellationToken cancellationToken)
    {
        return await _context.UserTokens
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.UserId == userId)
                             .ToListAsync();
    }

    public async Task<UserToken?> GetUserToken_ByUserTokenId(ulong userTokenId,
                                                            CancellationToken cancellation)
    {
        return await _context.UserTokens
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                  p.Id == userTokenId);
    }

    public async Task<UserToken?> Get_UserToken_ByRefreshToken(string refreshToken)
    {
        return await _context.UserTokens
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                  p.RefreshToken == refreshToken);
    }

    public async Task<SmsCode?> GetSMSCode_ByMobileAndCode(string mobile, string code)
    {
        return await _context.SmsCodes
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                  p.PhoneNumber == mobile &&
                                                  p.Code == code);
    }

    public async Task<bool> IsMobileExist(string mobile, CancellationToken cancellation)
    {
        return await _context.Users
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.Mobile == mobile);
    }

    public async Task<bool> IsUserActive(string mobile, CancellationToken cancellation)
    {
        return await _context.Users
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.Mobile == mobile &&
                                       p.IsActive);
    }

    public async Task<Domain.Entities.Account.User?> GetUserByMobile(string mobile, CancellationToken cancellation)
    {
        return await _context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                  p.Mobile == mobile);
    }

    #endregion

    #region Site Side

    public async Task<bool> CheckIsExist_UserToken(string hashedToken)
    {
        string tokenHash = hashedToken.Getsha256Hash();

        var userToken = _context.UserTokens
                                .Where(p => p.TokenHash == tokenHash)
                                .FirstOrDefault();

        return userToken == null ? false : true;
    }

    #endregion

    #region Admin Side 

    public async Task<FilterUsersDTO> FilterUsers(FilterUsersDTO filter, CancellationToken cancellation)
    {
        var query = _context.Users
                           .AsNoTracking()
                           .OrderByDescending(p => p.CreateDate)
                           .AsQueryable();

        #region filter

        if ((!string.IsNullOrEmpty(filter.Mobile)))
        {
            query = query.Where(u => u.Mobile.Contains(filter.Mobile));
        }

        if ((!string.IsNullOrEmpty(filter.Username)))
        {
            query = query.Where(u => u.Username.Contains(filter.Username));
        }

        #endregion

        #region paging

        await filter.Paging(query);

        #endregion

        return filter;
    }

    #endregion
}
