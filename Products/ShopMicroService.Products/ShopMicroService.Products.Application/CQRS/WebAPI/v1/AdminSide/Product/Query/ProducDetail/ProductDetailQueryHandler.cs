using ShopMicroService.Products.Domain.DTO.AdminSide.Products;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Query.ProducDetail;

public record ProductDetailQueryHandler : IRequestHandler<ProductDetailQuery, Product_Detail_AdminSideDTO>
{
    #region Ctor

    private readonly IProductQueryRepository _productQueryRepository;

    public ProductDetailQueryHandler(IProductQueryRepository productQueryRepository)
    {
        _productQueryRepository = productQueryRepository;
    }

    #endregion

    public async Task<Product_Detail_AdminSideDTO?> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
    {
        return await _productQueryRepository.Fill_ProductDetailAdminSideDTO(request.ProductId , cancellationToken);
    }
}
