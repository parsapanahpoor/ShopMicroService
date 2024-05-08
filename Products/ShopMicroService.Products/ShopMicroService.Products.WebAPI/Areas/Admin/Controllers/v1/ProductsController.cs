using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.CreateProduct;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.DeleteProduct;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.EditProduct;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Query.FilterProduct;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Query.ProducDetail;
using ShopMicroService.Products.Domain.DTO.AdminSide.Products;
using ShopMicroService.Products.Presentation.Areas.Admin.Controllers.v1;
using ShopMicroService.Products.Presentation.HttpManager;

namespace ShopMicroService.Products.WebAPI.Areas.Admin.Controllers.v1;


[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Admin/[controller]")]
public class ProductsController : AdminBaseController
{
    #region Filter Products 

    [HttpGet("filter-products")]
    public async Task<IActionResult> FilterProducts([FromQuery] FilterProductAdminSideQuery filter,
                                                    CancellationToken cancellationToken = default)
    {
        return Ok(JsonResponseStatus.Success(await Mediator.Send(filter)));
    }

    #endregion

    #region Create Product 

    [HttpPost("create-Product")]
    public async Task<IActionResult> CreateProduct([FromForm] Create_Product_AdminSideDTO model,
                                                   CancellationToken cancellationToken = default)
    {
        var res = await Mediator.Send(new CreateProductCommand()
        {
            CategoryId = model.CategoryId,
            Count = model.Count,
            Image = model.Image,
            LongDescription = model.LongDescription,
            ProductTitle = model.ProductTitle,
            ShortDescription = model.ShortDescription,
            UserId = 1
        });

        switch (res)
        {
            case true:
                return Ok(JsonResponseStatus.Success(null, "افزودن محصول جدید باموفقیت انجام شده است."));

            case false:
                return JsonResponseStatus.Error(null, "اطلاعات وارد شده صحیح نمی باشد.");
        }
    }

    #endregion

    #region Edit Product

    [HttpPut("edit-product")]
    public async Task<IActionResult> EditProduct([FromForm]Edit_Product_AdminSideDTO product , 
                                                 CancellationToken cancellationToken = default)
    {
        var res = await Mediator.Send(new EditProductCommand()
        {
            CategoryId = product.CategoryId,
            Count = product.Count,
            Image = product.Image,
            LongDescription = product.LongDescription,
            ProductTitle = product.ProductTitle,
            ShortDescription = product.ShortDescription,
            ProductId = product.ProductId,
            UserId = 1
        } , cancellationToken) ;

        switch (res)
        {
            case true:
                return Ok(JsonResponseStatus.Success(null, "ویرایش محصول باموفقیت انجام شده است."));

            case false:
                return JsonResponseStatus.Error(null, "اطلاعات وارد شده صحیح نمی باشد.");
        }
    }

    #endregion

    #region Product Detail 

    [HttpGet("product-detail/{productId}")]
    public async Task<IActionResult> ProductDetail(ulong productId , 
                                                   CancellationToken cancellation = default)
    {
        var res = await Mediator.Send(new ProductDetailQuery() { ProductId = productId }, cancellation);
        if (res == null) return JsonResponseStatus.Error(null , "مصحول موردنظر یافت نشده است.");

        return Ok(JsonResponseStatus.Success(res));
    }

    #endregion

    #region Delete Product

    [HttpDelete("delete-product/{productId}")]
    public async Task<IActionResult> DeleteProduct(ulong productId , 
                                                   CancellationToken cancellation = default)
    {
        var res = await Mediator.Send(new DeleteProductCommand() {ProductId = productId} , cancellation);
       
        switch (res)
        {
            case true:
                return Ok(JsonResponseStatus.Success(null, "جذف محصول باموفقیت انجام شده است."));

            case false:
                return JsonResponseStatus.Error(null, "اطلاعات وارد شده صحیح نمی باشد.");
        }
    }

    #endregion
}
