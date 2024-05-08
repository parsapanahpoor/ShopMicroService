using ShopMicroService.Products.Domain.DTO.Common;

namespace ShopMicroService.Products.Domain.DTO.AdminSide.Products;

public class FilterProductsAdminSideDTO : BasePaging<Entities.Products.Product>
{
    #region properties

    public string ProductTitle { get; set; }

    #endregion
}
