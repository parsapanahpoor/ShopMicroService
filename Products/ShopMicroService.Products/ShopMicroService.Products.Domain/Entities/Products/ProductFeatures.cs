using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShopMicroService.Products.Domain.Entities.Products;

public sealed class ProductFeatures : BaseEntities<ulong>
{
    #region properties

    public ulong ProductId { get; set; }

    public string FeatureKey { get; set; }

    public string FeatureValue { get; set; }

    #endregion
}
