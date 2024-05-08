namespace ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;

public record Create_ProductFeature_AdminSideDTO
{
    #region properties

    public ulong ProductId { get; set; }

    public string FeatureTitle { get; set; }

    public string FeatureValue { get; set; }

    #endregion
}
