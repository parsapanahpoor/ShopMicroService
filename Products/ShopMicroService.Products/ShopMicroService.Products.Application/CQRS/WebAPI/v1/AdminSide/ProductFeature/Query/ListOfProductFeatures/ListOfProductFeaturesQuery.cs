using ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Query.ListOfProductFeatures;

public record ListOfProductFeaturesQuery : IRequest<List<ListOf_ProductFeature_AdminSideDTO>>
{
    #region properties

    public ulong ProductId { get; set; }

    #endregion
}
