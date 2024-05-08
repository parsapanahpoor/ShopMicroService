#region Usings

using ShopMicroService.User.Infrastructure.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using ShopMicroService.User.Application.Common.IUnitOfWork;
using ShopMicroService.User.Domain.IRepositories.User;
using ShopMicroService.User.Infrastructure.UnitOfWork;

namespace ShopMicroService.User.IoC;

#endregion

public static class WebAPIDependencyContainer
{
    public static void ConfigureDependencies(IServiceCollection services)
    {
        //User
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();

        //Unit Of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
