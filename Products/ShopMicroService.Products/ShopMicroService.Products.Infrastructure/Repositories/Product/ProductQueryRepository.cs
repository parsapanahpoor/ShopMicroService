using Microsoft.EntityFrameworkCore;
using ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;
using ShopMicroService.Products.Domain.DTO.AdminSide.Products;
using ShopMicroService.Products.Domain.Entities.Products;
using ShopMicroService.Products.Domain.IRepositories.Products;
using ShopMicroService.Products.Infrastructure.ApplicationDbContext;

namespace ShopMicroService.Products.Infrastructure.Repositories.Product;

public class ProductQueryRepository : QueryGenericRepository<Domain.Entities.Products.Product>, IProductQueryRepository
{
    #region Ctor

    private readonly ShopMicroServiceProductsDbContext _context;

    public ProductQueryRepository(ShopMicroServiceProductsDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Admin Side 

    public async Task<ProductFeatures?> Get_ProductFeature_ById(ulong productFeatureId , 
                                                                CancellationToken cancellation)
    {
        return await _context.ProductFeatures
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                  p.Id == productFeatureId);
    }

    public async Task<List<ListOf_ProductFeature_AdminSideDTO>?> Fill_ListOf_ProductFeature_AdminSideDTO(ulong productId , 
                                                                                                         CancellationToken cancellationToken)
    {
        return await _context.ProductFeatures
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.ProductId == productId)
                             .Select(p => new ListOf_ProductFeature_AdminSideDTO()
                             {
                                 FeatureId = p.Id,
                                 FeatureTitle = p.FeatureKey,
                                 FeatureValue = p.FeatureValue
                             })
                             .ToListAsync();
    }

    public async Task<Product_Detail_AdminSideDTO?> Fill_ProductDetailAdminSideDTO(ulong productId , 
                                                                                   CancellationToken cancellationToken)
    {
        return await _context.Products
                             .AsNoTracking()
                             .Where(p => p.Id == productId)
                             .Select(p => new Product_Detail_AdminSideDTO()
                             {
                                 ProductId = productId,
                                 CategoryTitle = "فعلا درحال تست",
                                 Count = p.Count,
                                 Image = p.ImageName,
                                 LongDescription = p.LongDescription,
                                 ProductTitle = p.ProductTitle,
                                 ShortDescription = p.ShortDescription,
                                 Username = "فعلا در حال تست",
                             })
                             .FirstOrDefaultAsync();
    }

    public async Task<FilterProductsAdminSideDTO> FilterProducts_AdminSide(FilterProductsAdminSideDTO filter, 
                                                                           CancellationToken cancellation)
    {
        var query = _context.Products
                           .AsNoTracking()
                           .OrderByDescending(p => p.CreateDate)
                           .AsQueryable();

        #region filter

        if ((!string.IsNullOrEmpty(filter.ProductTitle)))
        {
            query = query.Where(u => u.ProductTitle.Contains(filter.ProductTitle));
        }

        #endregion

        #region paging

        await filter.Paging(query);

        #endregion

        return filter;
    }

    #endregion
}
