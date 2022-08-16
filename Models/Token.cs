using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Token
    {
        public string token { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

    }
}
