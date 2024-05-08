using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopMicroService.User.Domain.DTO.AdminSide.User;

public record EditUserDTO
{
    #region properties

    public ulong Id { get; set; }

    [Required(ErrorMessage = "Please Enter {0}")]
    [MaxLength(200)]
    public string? Username { get; set; }

    [MaxLength(200)]
    [Required(ErrorMessage = "Please Enter {0}")]
    public string Mobile { get; set; }

    public List<ulong>? UserRoles { get; set; }

    public IFormFile? UserAvatar { get; set; }

    public bool IsActive { get; set; }

    #endregion
}

public enum EditUserResult
{
    DuplicateEmail,
    DuplicateMobileNumber,
    Success,
    Error
}