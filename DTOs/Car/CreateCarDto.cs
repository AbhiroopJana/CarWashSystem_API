using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.DTOs.Car
{
    public class CreateCarDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
    }
}
