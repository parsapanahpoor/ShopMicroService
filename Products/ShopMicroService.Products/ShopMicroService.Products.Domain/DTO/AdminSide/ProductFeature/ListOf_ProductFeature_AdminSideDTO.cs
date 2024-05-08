namespace ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;

public record ListOf_ProductFeature_AdminSideDTO
{
    #region properties

    public ulong FeatureId { get; set; }

    public string FeatureTitle { get; set; }

    public string FeatureValue { get; set; }

    #endregion
}
