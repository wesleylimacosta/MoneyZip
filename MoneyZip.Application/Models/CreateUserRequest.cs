using System.ComponentModel.DataAnnotations;

namespace MoneyZip.Application.Models;

public record CreateUserRequest
{
    [Required(ErrorMessage = "UserType is required")]
    [RegularExpression(@"^(CommonUser|MerchantUser)$", ErrorMessage = "UserType must be 'CommonUser' or 'MerchantUser'")]
    public string UserType { get; init; } // "CommonUser" ou "MerchantUser"
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; init; }

    public string CPF { get; init; }
    public string CNPJ { get; init; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; init; }
        
}