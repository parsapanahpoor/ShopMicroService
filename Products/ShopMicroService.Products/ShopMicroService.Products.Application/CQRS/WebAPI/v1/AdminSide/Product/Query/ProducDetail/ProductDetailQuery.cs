using ShopMicroService.Products.Domain.DTO.AdminSide.Products;
using System.Security.Cryptography;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Query.ProducDetail;

public record ProductDetailQuery : IRequest<Product_Detail_AdminSideDTO>
{
    #region properties

    public ulong ProductId { get; set; }

    #endregion
}
