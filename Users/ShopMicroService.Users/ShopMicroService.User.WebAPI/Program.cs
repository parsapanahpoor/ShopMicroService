
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShopMicroService.User.IoC;
using Swashbuckle.AspNetCore.SwaggerGen;
using ShopMicroService.User.Application;
using System.Reflection;
using System.Text;
using ShopMicroService.User.Infrastructure.ApplicationDbContext;

#region Services

var builder = WebApplication.CreateBuilder(args);

#region MVC

builder.Services.AddControllers();
{
    builder.Services.RegisterApplicationServices();
}

#endregion

#region IoC Container

WebAPIDependencyContainer.ConfigureDependencies(builder.Services);

#endregion

#region Add DBContext

builder.Services.AddDbContext<ShopMicroServiceUserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopMicroServiceUserDbContextConnection"));
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion