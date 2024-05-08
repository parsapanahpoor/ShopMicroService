using Microsoft.EntityFrameworkCore;
using ShopMicroService.Products.Domain.Entities.Products;

namespace ShopMicroService.Products.Domain.IRepositories.Products;

public interface IProductCommandRepository
{
    Task AddAsync(Entities.Products.Product product, CancellationToken cancellationToken);

    void Update(Entities.Products.Product product);

    Task Create_ProductFeature(ProductFeatures productFeatures, CancellationToken cancellationToken);

    void Update_ProductFeature(ProductFeatures productFeatures);
}
