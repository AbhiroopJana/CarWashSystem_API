using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Washer
    {
        public int WasherId { get; set; }
        public string WasherName { get; set; } = null!;
        public string WasherPhnumber { get; set; } = null!;
        public string WasherEmail { get; set; } = null!;
        public string? WasherStatus { get; set; } = null;
    }
}
