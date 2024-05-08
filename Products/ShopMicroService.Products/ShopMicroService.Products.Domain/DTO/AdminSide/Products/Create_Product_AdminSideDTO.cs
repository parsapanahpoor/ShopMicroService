﻿using Microsoft.AspNetCore.Http;

namespace ShopMicroService.Products.Domain.DTO.AdminSide.Products;

public sealed class Create_Product_AdminSideDTO 
{
    #region properties

    public ulong CategoryId { get; set; }

    public int Count { get; set; }

    public string ProductTitle { get; set; }

    public string ShortDescription { get; set; }

    public string LongDescription { get; set; }

    public IFormFile Image { get; set; }

    #endregion
}
