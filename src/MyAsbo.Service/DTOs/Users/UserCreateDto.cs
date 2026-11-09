using MyAsbo.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAsbo.Service.DTOs.Users;

public class UserCreateDto
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
    [StringLength(50, ErrorMessage = "Login 50 belgidan oshmasligi kerak")]
    public string Login { get; set; } = string.Empty;

    [Required(ErrorMessage = "Parol kiritilishi shart")]
    [StringLength(72, MinimumLength = 8, ErrorMessage = "Parol 8 tadan 72 belgigacha bo’lishi kerak")]
    public string Password { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Telefon raqam 20 belgidan oshmasligi kerak")]
    public string? PhoneNumber { get; set; }

    [Range((int)UserRole.Accountant, (int)UserRole.HumanResources,
        ErrorMessage = "Rol faqat Buxgalter yoki Kadr bo'lishi mumkin")]
    public UserRole Role { get; set; }
}
