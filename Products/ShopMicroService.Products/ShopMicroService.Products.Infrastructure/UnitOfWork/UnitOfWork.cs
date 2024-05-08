using ShopMicroService.Products.Application.Common.IUnitOfWork;
using ShopMicroService.Products.Infrastructure.ApplicationDbContext;
namespace ShopMicroService.Products.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    #region Ctor

    private readonly ShopMicroServiceProductsDbContext _context;

    public UnitOfWork(ShopMicroServiceProductsDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Save Changes

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    #endregion
}
