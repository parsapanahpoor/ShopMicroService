using Microsoft.AspNetCore.Mvc;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.Product.Command.DeleteProduct;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Command.CreateProductFeature;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Command.DeleteProductFeature;
using ShopMicroService.Products.Application.CQRS.WebAPI.v1.AdminSide.ProductFeature.Query.ListOfProductFeatures;
using ShopMicroService.Products.Domain.DTO.AdminSide.ProductFeature;
using ShopMicroService.Products.Presentation.Areas.Admin.Controllers.v1;
using ShopMicroService.Products.Presentation.HttpManager;

namespace ShopMicroService.Products.WebAPI.Areas.Admin.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Admin/[controller]")]
public class ProductFeatureController : AdminBaseController
{
    #region List Of Product Features

    [HttpGet("list-productFeatures/{productId}")]
    public async Task<IActionResult> FilterProductFeatures(ulong productId, CancellationToken cancellationToken = default)
    {
        return Ok(await Mediator.Send(new ListOfProductFeaturesQuery()
        {
            ProductId = productId,
        }, cancellationToken));
    }

    #endregion

    #region Create Product Feature

    [HttpPost("create-productFeature")]
    public async Task<IActionResult> CreateProductFeature([FromBody] Create_ProductFeature_AdminSideDTO product,
                                                          CancellationToken cancellation = default)
    {
        var res = await Mediator.Send(new CreateProductFeatureCommand()
        {
            ProductFeature = product,
        }, cancellation);

        switch (res)
        {
            case true:
                return Ok(JsonResponseStatus.Success(null, "افزودن ویژگی جدید باموفقیت انجام شده است."));

            case false:
                return JsonResponseStatus.Error(null, "اطلاعات وارد شده صحیح نمی باشد.");
        }
    }

    #endregion

    #region Delete Product Feature

    [HttpDelete("delete-productFeature/{productFeatureId}")]
    public async Task<IActionResult> DeleteProductFeature(ulong productFeatureId , 
                                                          CancellationToken cancellation)
    {
        var res = await Mediator.Send(new DeleteProductFeatureCommand()
        {
            ProductFeatureId = productFeatureId
        }, cancellation);

        switch (res)
        {
            case true:
                return Ok(JsonResponseStatus.Success(null, "حذف ویژگی باموفقیت انجام شده است."));

            case false:
                return JsonResponseStatus.Error(null, "اطلاعات وارد شده صحیح نمی باشد.");
        }
    }

    #endregion
}
