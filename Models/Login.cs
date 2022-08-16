using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Login
    {
        [Required]
        public string Role { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
