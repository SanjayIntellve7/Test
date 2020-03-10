using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Models
{
    public class ApplicationUser
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public Guid Token { get; set; }
        public string Identifier { get; set; }
    }
}
