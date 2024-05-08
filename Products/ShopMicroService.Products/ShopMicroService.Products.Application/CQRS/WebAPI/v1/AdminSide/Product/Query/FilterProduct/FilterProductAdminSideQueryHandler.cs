using ShopMicroService.Products.Domain.DTO.AdminSide.Products;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Query.FilterProduct;

public record FilterProductAdminSideQueryHandler: IRequestHandler<FilterProductAdminSideQuery, FilterProductsAdminSideDTO>
{
    #region Ctor

    private readonly IProductQueryRepository _productQueryRepository;

    public FilterProductAdminSideQueryHandler(IProductQueryRepository productQueryRepository)
    {
        _productQueryRepository = productQueryRepository; 
    }

    #endregion

    public async Task<FilterProductsAdminSideDTO> Handle(FilterProductAdminSideQuery request, CancellationToken cancellationToken)
    {
        return await _productQueryRepository.FilterProducts_AdminSide(request.Filter , cancellationToken);
    }
}
