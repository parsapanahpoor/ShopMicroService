#region properties

using Microsoft.EntityFrameworkCore;
using ShopMicroService.User.Domain.Entities.Account;
namespace ShopMicroService.User.Infrastructure.ApplicationDbContext;

#endregion

public class ShopMicroServiceUserDbContext : DbContext
{
    #region Ctor

    public ShopMicroServiceUserDbContext(DbContextOptions<ShopMicroServiceUserDbContext> options)
           : base(options)
    {

    }

    #endregion

    #region Entity

    #region User

    public DbSet<Domain.Entities.Account.User> Users { get; set; }

    public DbSet<SmsCode> SmsCodes { get; set; }

    public DbSet<UserToken> UserTokens { get; set; }

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
