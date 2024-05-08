using ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Command.CreateProductFeature;

public record CreateProductFeatureCommand : IRequest<bool>
{
    #region properties

    public Create_ProductFeature_AdminSideDTO ProductFeature { get; set; }

    #endregion
}
