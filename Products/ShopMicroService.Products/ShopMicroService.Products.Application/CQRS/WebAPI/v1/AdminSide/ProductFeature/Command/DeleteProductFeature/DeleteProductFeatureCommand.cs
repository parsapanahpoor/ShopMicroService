namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Command.DeleteProductFeature;

public record DeleteProductFeatureCommand : IRequest<bool>
{
    #region proeprties

    public ulong ProductFeatureId { get; set; }

    #endregion
}
