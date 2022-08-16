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
    public class ViewWasherController : ControllerBase
    {
        public readonly ViewWasherService _Service;

        public ViewWasherController(ViewWasherService service)
        {
            _Service = service;
        }

        [HttpGet]
        public List<Washer> ViewWashersAsync()
        {
            return _Service.ViewWashersAsync();
        }
    }
}
