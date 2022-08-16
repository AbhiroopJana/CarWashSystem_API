using CarWashApi.Models;
using CarWashApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewCustomersController : ControllerBase
    {

        public readonly ViewCustomerService _Service;

        public ViewCustomersController(ViewCustomerService service)
        {
            _Service = service;
        }

        [HttpGet]
        public List<Customer> ViewCustomersAsync()
        {
            return _Service.ViewCustomersAsync();
        }
    }
}
