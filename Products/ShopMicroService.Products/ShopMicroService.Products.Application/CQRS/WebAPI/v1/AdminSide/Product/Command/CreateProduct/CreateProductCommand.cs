using Microsoft.AspNetCore.Http;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.CreateProduct;

public record CreateProductCommand : IRequest<bool>
{
    #region properties

    public ulong UserId { get; set; }

    public ulong CategoryId { get; set; }

    public int Count { get; set; }

    public string ProductTitle { get; set; }

    public string ShortDescription { get; set; }

    public string LongDescription { get; set; }

    public IFormFile Image { get; set; }

    #endregion
}
