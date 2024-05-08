using ShopMicroService.User.Application.StaticTools;
using ShopMicroService.User.Domain.DTO.AdminSide.User;
using ShopMicroService.User.Domain.IRepositories.User;

namespace ShopMicroService.User.Application.CQRS.APIClient.v1.AdminSide.User.Query.UserDetailQuery;

public record UserDetailAdminSideQueryHandler : IRequestHandler<UserDetailAdminSideQuery, UserDetailAdminSideDTO>
{
    #region ctor

    private readonly IUserQueryRepository _userQueryRepository;

    public UserDetailAdminSideQueryHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    #endregion

    public async Task<UserDetailAdminSideDTO?> Handle(UserDetailAdminSideQuery request, CancellationToken cancellationToken = default)
    {
        //Get User By Id 
        var user = await _userQueryRepository.GetByIdAsync(cancellationToken , request.UserId);
        if (user == null) return null;

        return new UserDetailAdminSideDTO()
        {
            UserId = user.Id,
            Avatar = $"{FilePaths.SiteAddress}{ FilePaths.UserAvatarPathThumb}/{user.Avatar}",
            IsActive = user.IsActive,
            IsAdmin = user.IsAdmin,
            Mobile = user.Mobile,
            Username = user.Username,
        };
    }
}
