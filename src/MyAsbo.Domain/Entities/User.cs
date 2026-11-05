using MyAsbo.Domain.Commons;
using MyAsbo.Domain.Enums;

namespace MyAsbo.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;

        public long? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
