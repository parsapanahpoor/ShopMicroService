using Microsoft.AspNetCore.Http;

namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.EditProduct;

public record EditProductCommand : IRequest<bool>
{
    #region properties

    public ulong ProductId { get; set; }

    public ulong UserId { get; set; }

    public ulong CategoryId { get; set; }

    public int Count { get; set; }

    public string ProductTitle { get; set; }

    public string ShortDescription { get; set; }

    public string LongDescription { get; set; }

    public IFormFile? Image { get; set; }

    #endregion
}
