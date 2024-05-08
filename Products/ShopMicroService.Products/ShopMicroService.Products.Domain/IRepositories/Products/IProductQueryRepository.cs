using ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;
using ShopMicroService.Products.Domain.DTO.AdminSide.Products;
using ShopMicroService.Products.Domain.Entities.Products;

namespace ShopMicroService.Products.Domain.IRepositories.Products;

public interface IProductQueryRepository
{
    #region General 

    Task<Domain.Entities.Products.Product> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);

    #endregion

    #region Admin Side 

    Task<ProductFeatures?> Get_ProductFeature_ById(ulong productFeatureId,
                                                   CancellationToken cancellation);

    Task<Product_Detail_AdminSideDTO?> Fill_ProductDetailAdminSideDTO(ulong productId,
                                                                      CancellationToken cancellationToken);

    Task<FilterProductsAdminSideDTO> FilterProducts_AdminSide(FilterProductsAdminSideDTO filter,
                                                              CancellationToken cancellation);

    Task<List<ListOf_ProductFeature_AdminSideDTO>?> Fill_ListOf_ProductFeature_AdminSideDTO(ulong productId,
                                                                                            CancellationToken cancellationToken);

    #endregion

}
