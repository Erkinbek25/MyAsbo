using System.ComponentModel.DataAnnotations;


namespace MyAsbo.Service.DTOs.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "Login kiritilishi shart")]
    public string Login { get; set; } = string.Empty;
    [Required(ErrorMessage = "Parol kiritilishi shart")]
    public string Password { get; set; } = string.Empty;


}
