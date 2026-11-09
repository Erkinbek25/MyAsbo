using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsbo.Service.DTOs.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "Ism kiritilishi shart")]
    [StringLength(100, ErrorMessage = "Ism 100 belgidan oshmasligi kerak")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Familya kiritilishi shart")]
    [StringLength(100, ErrorMessage = "Familya 100 belgidan oshmasligi kerak")]
    public string LastName { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Sharif 100 belgidan oshmasligi kerak")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Login kiritilishi shart")]
    [StringLength(50, ErrorMessage = "Login 500 belgidan oshmasligi kerak")]
    public string Login { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Telefon raqam 20 belgidan oshmasligi kerak")]
    public string? PhoneNumber { get; set; } = string.Empty; 


}
