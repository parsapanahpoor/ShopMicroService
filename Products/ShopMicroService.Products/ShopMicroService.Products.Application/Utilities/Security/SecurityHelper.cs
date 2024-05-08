using System.Security.Cryptography;
using System.Text;
namespace ShopMicroService.Products.Application.Utilities.Security;

public static class SecurityHelper
{
    public static string Getsha256Hash(this string value)
    {
        var algoritm = new SHA256CryptoServiceProvider();
        var byteValue = Encoding.UTF8.GetBytes(value);
        var byteHash = algoritm.ComputeHash(byteValue);
        return Convert.ToBase64String(byteHash);
    }
}
