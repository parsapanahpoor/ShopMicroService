#region Usings

using Microsoft.Extensions.DependencyInjection;
using ShopMicroService.Products.Application.Common.IUnitOfWork;
using ShopMicroService.Products.Domain.IRepositories.Products;
using ShopMicroService.Products.Infrastructure.Repositories.Product;
using ShopMicroService.Products.Infrastructure.UnitOfWork;

namespace ShopMicroService.Products.IoC;

#endregion

public static class WebAPI_DependencyContainer
{
    public static void ConfigureDependencies(IServiceCollection services)
    {
        //Product
        services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
        services.AddScoped<IProductQueryRepository, Infrastructure.Repositories.Product.ProductQueryRepository>();

        //Unit Of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
