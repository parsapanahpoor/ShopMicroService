
using ShopMicroService.Products.Application.Common.IUnitOfWork;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Command.DeleteProductFeature;

public record DeleteProductFeatureCommandHandler : IRequestHandler<DeleteProductFeatureCommand, bool>
{
    #region ctor

    private readonly IProductCommandRepository _productCommandRepository;
    private readonly IProductQueryRepository _productQueryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductFeatureCommandHandler(IProductCommandRepository productCommandRepository ,
                                              IProductQueryRepository productQueryRepository ,
                                              IUnitOfWork unitOfWork)
    {
        _productCommandRepository = productCommandRepository;
        _productQueryRepository = productQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteProductFeatureCommand request, CancellationToken cancellationToken)
    {
        //Get Product Feature
        var productFeature = await _productQueryRepository.Get_ProductFeature_ById(request.ProductFeatureId , cancellationToken);
        if (productFeature == null) return false;

        productFeature.IsDelete = true;

        //Update Product Feature
        _productCommandRepository.Update_ProductFeature(productFeature);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
