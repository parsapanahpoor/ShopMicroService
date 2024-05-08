using ShopMicroService.Products.Domain.DTO.AdminSide.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Query.FilterProduct;

public record FilterProductAdminSideQuery : IRequest<FilterProductsAdminSideDTO>
{
    #region properties

    public FilterProductsAdminSideDTO Filter { get; set; }

    #endregion
}
