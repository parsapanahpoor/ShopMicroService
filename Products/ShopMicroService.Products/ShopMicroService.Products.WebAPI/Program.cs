using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using ShopMicroService.Products.Application;
using ShopMicroService.Products.Infrastructure.ApplicationDbContext;
using ShopMicroService.Products.IoC;

#region Services

var builder = WebApplication.CreateBuilder(args);

#region MVC

builder.Services.AddControllers();
{
    builder.Services.RegisterApplicationServices();
}

#endregion

#region IoC Container

WebAPI_DependencyContainer.ConfigureDependencies(builder.Services);

#endregion

#region Add DBContext

builder.Services.AddDbContext<ShopMicroServiceProductsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopMicroServiceProductsDbContextConnection"));
});

#endregion

#region Api Versioning

builder.Services.AddApiVersioning(Options =>
{
    Options.AssumeDefaultVersionWhenUnspecified = true;//ای پی آی های قبلی باورژن دیفالت ست بشوند
    Options.DefaultApiVersion = new ApiVersion(1, 0);//معرفی ورژن دیفالت
    Options.ReportApiVersions = true; //افزودن اطلاعات ورژن جاری به هدر جواب درخواست کاربر
});

#endregion

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopMicroService", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "ShopMicroService", Version = "v2" });

    c.DocInclusionPredicate((doc, apiDescription) =>
    {
        if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

        var version = methodInfo.DeclaringType
            .GetCustomAttributes<ApiVersionAttribute>(true)
            .SelectMany(attr => attr.Versions);

        return version.Any(v => $"v{v.ToString()}" == doc);
    });

});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#endregion

#region Middlewares

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //بااستفاده از رفلکشن تمام ای پی آی های مان را پیدا میکند
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("ApiCORS");

app.MapControllers();

app.Run();

#endregion