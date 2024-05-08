#region properties

using Microsoft.EntityFrameworkCore;
namespace ShopMicroService.Products.Infrastructure.ApplicationDbContext;

#endregion

public class ShopMicroServiceProductsDbContext : DbContext
{
    #region Ctor

    public ShopMicroServiceProductsDbContext(DbContextOptions<ShopMicroServiceProductsDbContext> options)
           : base(options)
    {

    }

    #endregion

    #region Entity

    #region User

    public DbSet<ShopMicroService.Products.Domain.Entities.Products.Product> Products { get; set; }
    public DbSet<ShopMicroService.Products.Domain.Entities.Products.ProductFeatures> ProductFeatures{ get; set; }

    #endregion

    #endregion

    #region OnConfiguring

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
