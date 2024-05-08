
using ShopMicroService.Products.Application.Common.IUnitOfWork;
using ShopMicroService.Products.Application.Extensions;
using ShopMicroService.Products.Application.Generators;
using ShopMicroService.Products.Application.Security;
using ShopMicroService.Products.Application.StaticTools;
using ShopMicroService.Products.Domain.IRepositories.Products;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.CreateProduct;

public record CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
{
    #region Ctor

    private readonly IProductCommandRepository _productCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductCommandRepository productCommandRepository,
                                       IUnitOfWork unitOfWork)
    {
        _productCommandRepository = productCommandRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Products.Product product = new Domain.Entities.Products.Product()
        {
            CategoryId = request.CategoryId,
            Count = request.Count,
            CreateDate = DateTime.Now,
            LongDescription = request.LongDescription,
            ProductTitle = request.ProductTitle,
            ShortDescription = request.ShortDescription,
            UserId = 1,
        };

        //Add Image To The Server
        if (request.Image != null && request.Image.IsImage())
        {
            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(request.Image.FileName);
            request.Image.AddImageToServer(imageName, FilePaths.ProductPathServer, 270, 270, FilePaths.ProductPathThumbServer);
            product.ImageName = imageName;
        }

        //Add product to the data base 
        await _productCommandRepository.AddAsync(product , cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
