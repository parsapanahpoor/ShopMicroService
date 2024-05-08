using ShopMicroService.User.Application.Common.IUnitOfWork;
using ShopMicroService.User.Application.Extensions;
using ShopMicroService.User.Application.Generators;
using ShopMicroService.User.Application.Security;
using ShopMicroService.User.Application.StaticTools;
using ShopMicroService.User.Application.Utilities.Security;
using ShopMicroService.User.Domain.DTO.AdminSide.User;
using ShopMicroService.User.Domain.IRepositories.User;

namespace ShopMicroService.User.Application.CQRS.APIClient.v1.AdminSide.User.Command.EditUser;

public record EditUserAdminSideCommandHandler : IRequestHandler<EditUserAdminSideCommand, EditUserResult>
{
    #region Ctor

    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditUserAdminSideCommandHandler(IUserCommandRepository userCommandRepository,
                                  IUserQueryRepository userQueryRepository,
                                  IUnitOfWork unitOfWork)
    {
        _userCommandRepository = userCommandRepository;
        _userQueryRepository = userQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<EditUserResult> Handle(EditUserAdminSideCommand request, CancellationToken cancellationToken)
    {
        //Get User By Id 
        var userOldInfos = await _userQueryRepository.GetByIdAsync(cancellationToken, request.Id);
        if (userOldInfos == null) return EditUserResult.Error;

        //Checkind incomin mobile 
        if (await _userQueryRepository.IsMobileExist(request.Mobile, cancellationToken) && request.Mobile != userOldInfos.Mobile)
        {
            return EditUserResult.DuplicateMobileNumber;
        }

        if (userOldInfos != null)
        {
            userOldInfos.Username = request.Username;
            userOldInfos.IsActive = request.IsActive;
            userOldInfos.UpdateDate = DateTime.Now;

            #region User Avatar

            if (request.Avatar != null && request.Avatar.IsImage())
            {
                if (!string.IsNullOrEmpty(userOldInfos.Avatar))
                {
                    userOldInfos.Avatar.DeleteImage(FilePaths.UserAvatarPathServer, FilePaths.UserAvatarPathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(request.Avatar.FileName);
                request.Avatar.AddImageToServer(imageName, FilePaths.UserAvatarPathServer, 270, 270, FilePaths.UserAvatarPathThumbServer);
                userOldInfos.Avatar = imageName;
            }

            #endregion

            _userCommandRepository.Update(userOldInfos);

            #region Delete User Roles

        

            #endregion

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return EditUserResult.Success;
        }

        return EditUserResult.Error;
    }
}
