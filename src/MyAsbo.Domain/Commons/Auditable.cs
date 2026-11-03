using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsbo.Domain.Commons
{
    public class Auditable
    {
        public long Id { get; set; }
        public DateTime CereatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
