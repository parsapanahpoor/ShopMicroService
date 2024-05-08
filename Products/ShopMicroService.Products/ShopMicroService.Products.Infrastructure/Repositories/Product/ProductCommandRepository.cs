using ShopMicroService.Products.Domain.Entities.Products;
using ShopMicroService.Products.Domain.IRepositories.Products;
using ShopMicroService.Products.Infrastructure.ApplicationDbContext;

namespace ShopMicroService.Products.Infrastructure.Repositories.Product;

public class ProductCommandRepository : CommandGenericRepository<Domain.Entities.Products.Product>, IProductCommandRepository
{
    #region Ctor

    private readonly ShopMicroServiceProductsDbContext _context;

    public ProductCommandRepository(ShopMicroServiceProductsDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public async Task Create_ProductFeature(ProductFeatures productFeatures , CancellationToken cancellationToken)
    {
        await _context.ProductFeatures.AddAsync(productFeatures);
    }

    public void Update_ProductFeature(ProductFeatures productFeatures)
    {
        _context.ProductFeatures.Update(productFeatures);
    }
}
