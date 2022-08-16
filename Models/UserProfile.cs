using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPhnumber { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public byte[]? UserPasswordHash { get; set; }
        public byte[] UserPasswordSalt { get; set; } = null!;
        public string? UserStatus { get; set; } = null;
        public string Role { get; set; }
    }
}
