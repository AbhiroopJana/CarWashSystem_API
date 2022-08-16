using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserAddress { get; set; }

        [Required]
        public string UserPhnumber { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }
        
        [Required]
        public string UserStatus{ get; set; }

        [Required]
        public string Role { get; set; }

    }
}
