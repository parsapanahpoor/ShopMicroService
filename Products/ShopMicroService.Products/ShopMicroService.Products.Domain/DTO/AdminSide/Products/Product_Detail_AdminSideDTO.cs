using Microsoft.AspNetCore.Http;

namespace ShopMicroService.Products.Domain.DTO.AdminSide.Products;

public record Product_Detail_AdminSideDTO 
{
    #region properties

    public ulong ProductId { get; set; }

    public string CategoryTitle { get; set; }

    public string Username { get; set; }

    public int Count { get; set; }

    public string ProductTitle { get; set; }

    public string ShortDescription { get; set; }

    public string LongDescription { get; set; }

    public string? Image { get; set; }

    #endregion
}
