using CarWashApi.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly CarWashContext _context;
        public UserController(CarWashContext context)
        {
            _context = context;

        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ChangeUserStatus(int id, string UserStatus)
        {
            (from p in _context.UserProfiles
             where p.UserId == id
             select p).ToList()
                    .ForEach(x => x.UserStatus = UserStatus);

            _context.SaveChanges();
            return Ok();
        }
    }
}