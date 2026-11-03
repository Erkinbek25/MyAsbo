using MyAsbo.Domain.Commons;
using MyAsbo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsbo.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; } // Email
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;

        public long? OrganizationId { get; set; }
        public Organization? organization { get; set; }
    }
}
