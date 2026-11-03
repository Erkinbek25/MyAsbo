using MyAsbo.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsbo.Domain.Entities
{
    public class Organization : Auditable
    {
        public string Name { get; set; } = string.Empty;
        public string Inn { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
