using CarWashApi.Models;
using CarWashApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly CarWashContext _context;
        private PackageService packageService;

        public PackagesController(CarWashContext context, PackageService _packageService)
        {
            _context = context;
            packageService = _packageService;
        }

        // GET: api/Packages

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
        {
            if (_context.Packages== null)
            {
                return NotFound();
            }
            return await _context.Packages.ToListAsync();
        }

        // GET: api/Packages/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
            if (_context.Packages == null)
            {
                return NotFound();
            }
            var admin = await _context.Packages.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/Packages/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Admins
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
            if (_context.Packages == null)
            {
                return Problem("Entity set 'CarWashContext.Packages'  is null.");
            }
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();


            //packageService.SendEmail(package);
            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            if (_context.Packages == null)
            {
                return NotFound();
            }
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageExists(int id)
        {
            return (_context.Packages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}