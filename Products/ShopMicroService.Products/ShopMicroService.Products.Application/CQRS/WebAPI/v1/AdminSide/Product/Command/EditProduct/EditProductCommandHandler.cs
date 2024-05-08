using ShopMicroService.Products.Application.Common.IUnitOfWork;
using ShopMicroService.Products.Application.Extensions;
using ShopMicroService.Products.Application.Generators;
using ShopMicroService.Products.Application.Security;
using ShopMicroService.Products.Application.StaticTools;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.EditProduct;

public record EditProductCommandHandler : IRequestHandler<EditProductCommand, bool>
{
    #region Ctor

    private readonly IProductCommandRepository _productCommandRepository;
    private readonly IProductQueryRepository _productQueryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditProductCommandHandler(IProductCommandRepository productCommandRepository, 
                                     IProductQueryRepository productQueryRepository,
                                     IUnitOfWork unitOfWork)
    {
        _productCommandRepository = productCommandRepository;
        _productQueryRepository = productQueryRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        //Get Product By Id 
        var product = await _productQueryRepository.GetByIdAsync(cancellationToken , request.ProductId);
        if (product == null) return false;

        product.UpdateDate = DateTime.Now;
        product.ShortDescription = request.ShortDescription;
        product.CategoryId = request.CategoryId;
        product.Count = request.Count;
        product.LongDescription = request.LongDescription;
        product.ProductTitle = request.ProductTitle;

        //Update Image To The Server
        if (request.Image != null && request.Image.IsImage())
        {
            if (!string.IsNullOrEmpty(product.ImageName))
            {
                product.ImageName.DeleteImage(FilePaths.ProductPathServer, FilePaths.ProductPathThumbServer);
            }

            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(request.Image.FileName);
            request.Image.AddImageToServer(imageName, FilePaths.ProductPathServer, 270, 270, FilePaths.ProductPathThumbServer);
            product.ImageName = imageName;
        }

        //Update product to the data base 
        _productCommandRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
