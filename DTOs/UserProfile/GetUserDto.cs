using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.DTOs.UserProfile
{
    public class GetUserDto : BaseUserDto
    {
        public string UserName { get; set; } = null!;
        public string UserPhnumber { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserStatus { get; set; } = null;
    }
}
