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
    public class ViewInvoiceController : ControllerBase
    {
        public readonly ViewInvoiceService _Service;

        public ViewInvoiceController(ViewInvoiceService service)
        {
            _Service = service;
        }

        [HttpGet]
        public List<Invoice> ViewInvoice(string email)
        {
            return _Service.ViewInvoice(email);
        }
    }
}
