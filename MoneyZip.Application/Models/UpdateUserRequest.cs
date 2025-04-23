using System.ComponentModel.DataAnnotations;

namespace MoneyZip.Application.Models;

public record UpdateUserRequest
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; init; }

    [Required(ErrorMessage = "CPF is required")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF must be 11 digits")]
    public string CPF { get; init; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
    public string Name { get; init; }
}