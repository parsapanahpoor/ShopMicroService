namespace ShopMicroService.Products.Domain.Entities.Products;

public sealed class Product : BaseEntities<ulong>
{
    #region properties

    public ulong UserId { get; set; }

    public ulong CategoryId { get; set; }

    public int Count { get; set; }

    public string ProductTitle { get; set; }

    public string ShortDescription { get; set; }

    public string LongDescription { get; set; }

    public string ImageName { get; set; }

    #endregion
}
