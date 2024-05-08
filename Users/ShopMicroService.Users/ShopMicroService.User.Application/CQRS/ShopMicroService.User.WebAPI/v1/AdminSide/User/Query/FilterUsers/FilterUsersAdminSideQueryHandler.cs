using ShopMicroService.User.Application.CQRS.APIClient.v1.AdminSide.User.Query;
using ShopMicroService.User.Domain.DTO.AdminSide.User;
using ShopMicroService.User.Domain.IRepositories.User;

namespace ShopMicroService.User.CQRS.APIClient.v1.AdminSide.User.Query;

public record FilterUsersAdminSideQueryHandler : IRequestHandler<FilterUsersAdminSideQuery, FilterUsersDTO>
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;

    public FilterUsersAdminSideQueryHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    #endregion

    public async Task<FilterUsersDTO> Handle(FilterUsersAdminSideQuery request, CancellationToken cancellationToken)
    {
        return await _userQueryRepository.FilterUsers(new FilterUsersDTO()
        {
            Username = request.Username,
            Mobile = request.Mobile
        }, cancellationToken);
    }
}
