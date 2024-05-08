using ShopMicroService.User.Application.Common.IUnitOfWork;
using ShopMicroService.User.Infrastructure.ApplicationDbContext;
namespace ShopMicroService.User.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    #region Using

    private readonly ShopMicroServiceUserDbContext _context;

    public UnitOfWork(ShopMicroServiceUserDbContext context)
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
