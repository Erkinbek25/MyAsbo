using System.ComponentModel.DataAnnotations;

namespace MyAsbo.Service.DTOs.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "Ism kiritilishi shart")]
    [StringLength(100, ErrorMessage = "Ism 100 belgidan oshmasligi kerak")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Familiya kiritilishi shart")]
    [StringLength(100, ErrorMessage = "Familiya 100 belgidan oshmasligi kerak")]
    public string LastName { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Sharif 100 belgidan oshmasligi kerak")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Login kiritilishi shart")]
    [StringLength(72, MinimumLength = 8, ErrorMessage = "Login 72 belgidan oshmasligi kerak")]
    public string Login { get; set; } = string.Empty;

    [Required(ErrorMessage = "Parol kiritilishi shart")]
    [StringLength(72, MinimumLength = 8, ErrorMessage = "Parol 72 belgidan oshmasligi kerak")]
    public string Password { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Telefon raqam 20 belgidan oshmasligi kerak")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "STIR kritilishi shart")]
    [RegularExpression("^[0-9]{9}$", ErrorMessage = "STIR aniq 9 ta raqamdan iborat bo'lishi kerak")]
    public string Inn { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Tashkilot nomi 200 belgidan oshmasligi kerak")]
    public string OrganizationName { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Manzil 500 belgidan oshmasligi kerak")]
    public string? Address { get; set; }

    [StringLength(20, ErrorMessage = "Tashkilot telefon raqami 20 belgidan oshmasligi kerak")]
    public string? OrganizationPhoneNumber { get; set; }


}
