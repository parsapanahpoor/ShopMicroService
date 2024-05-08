
using ShopMicroService.Products.Application.Common.IUnitOfWork;
using ShopMicroService.Products.Domain.Entities.Products;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Command.CreateProductFeature;

public record CreateProductFeatureCommandHandler : IRequestHandler<CreateProductFeatureCommand, bool>
{
    #region Ctor

    private readonly IProductCommandRepository _productCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductFeatureCommandHandler(IProductCommandRepository productCommandRepository ,
                                              IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _productCommandRepository = productCommandRepository;
    }


    #endregion

    public async Task<bool> Handle(CreateProductFeatureCommand request, CancellationToken cancellationToken)
    {
        //Initial product feature
        ProductFeatures productFeatures = new ProductFeatures()
        {
            ProductId = request.ProductFeature.ProductId,
            FeatureKey = request.ProductFeature.FeatureTitle,
            FeatureValue = request.ProductFeature.FeatureValue,
        };

        //Add To the data base 
        await _productCommandRepository.Create_ProductFeature(productFeatures , cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
