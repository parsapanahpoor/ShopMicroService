
using ShopMicroService.Products.Application.Common.IUnitOfWork;
using ShopMicroService.Products.Application.Extensions;
using ShopMicroService.Products.Application.StaticTools;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.DeleteProduct;

public record DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    #region Ctor

    private readonly IProductCommandRepository _productCommandRepository;
    private readonly IProductQueryRepository _productQueryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductCommandRepository productCommandRepository,
                                     IProductQueryRepository productQueryRepository,
                                     IUnitOfWork unitOfWork)
    {
        _productCommandRepository = productCommandRepository;
        _productQueryRepository = productQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        //Get Product By Id 
        var product = await _productQueryRepository.GetByIdAsync(cancellationToken, request.ProductId);
        if (product == null) return false;

        product.IsDelete = true;

        //Remove Origin Image
        if (!string.IsNullOrEmpty(product.ImageName))
        {
            product.ImageName.DeleteImage(FilePaths.ProductPathServer, FilePaths.ProductPathThumbServer);
        }

        //Update product to the data base 
        _productCommandRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
