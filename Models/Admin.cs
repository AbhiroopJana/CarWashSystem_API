using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminEmail { get; set; } = null!;
        public string AdminPassword { get; set; } = null!;
    }
}
