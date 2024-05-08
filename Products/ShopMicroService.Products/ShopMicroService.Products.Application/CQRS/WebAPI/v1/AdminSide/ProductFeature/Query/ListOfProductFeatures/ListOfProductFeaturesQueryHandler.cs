using ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Query.ListOfProductFeatures;

public record ListOfProductFeaturesQueryHandler : IRequestHandler<ListOfProductFeaturesQuery, List<ListOf_ProductFeature_AdminSideDTO>>
{
    #region Ctor

    private readonly IProductQueryRepository _productQueryRepository;

    public ListOfProductFeaturesQueryHandler(IProductQueryRepository productQueryRepository)
    {
        _productQueryRepository = productQueryRepository;
    }

    #endregion

    public async Task<List<ListOf_ProductFeature_AdminSideDTO>?> Handle(ListOfProductFeaturesQuery request, CancellationToken cancellationToken)
    {
        return await _productQueryRepository.Fill_ListOf_ProductFeature_AdminSideDTO(request.ProductId, cancellationToken);
    }
}
