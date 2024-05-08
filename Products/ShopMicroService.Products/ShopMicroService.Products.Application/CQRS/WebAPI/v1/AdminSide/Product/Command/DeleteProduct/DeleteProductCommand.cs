namespace ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.DeleteProduct;

public record DeleteProductCommand : IRequest<bool>
{
    #region properties

    public ulong ProductId { get; set; }

    #endregion
}
