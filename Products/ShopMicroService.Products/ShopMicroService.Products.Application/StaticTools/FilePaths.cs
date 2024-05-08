namespace ShopMicroService.Products.Application.StaticTools;

public static class FilePaths
{
    #region Site

    public static string SiteFarsiName = "وب سایت فروشگاهی شرکت گندوم ";
    public static string SiteAddress = "https://localhost:7075";
    public static string merchant = "123456789";

    #endregion

    #region Product 

    public static readonly string ProductPath = "/content/images/Product/main/";
    public static readonly string ProductPathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/Product/main/");

    public static readonly string ProductPathThumb = "/content/images/Product/thumb/";
    public static readonly string ProductPathThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/Product/thumb/");

    public static readonly string DefaultProductImage = "/content/images/Product/DefaultProduct.png";

    #endregion
}
