using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarWashApi.Models;
using AutoMapper;
using CarWashApi.DTOs;

namespace CarWashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarWashContext _context;
        private readonly IMapper mapper;

        public CarsController(CarWashContext context, IMapper mapper)  //Constructor (DI) injection
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInfo>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInfo>> GetCarInfo(int id)
        {
            var carInfo = await _context.Cars.FindAsync(id);

            if (carInfo == null)
            {
                return NotFound();
            }

            return carInfo;
        }

        // PUT: api/Cars/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarInfo(int id, UpdateCarsDto carDto)
        {
            if (id != carDto.CarId)
            {
                return BadRequest();
            }


            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            mapper.Map(carDto, car);

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarInfoExists(id))
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

        // POST: api/Cars

        [HttpPost]
        public async Task<ActionResult<CarInfo>> PostCarInfo(CarInfo carInfo)
        {
            _context.Cars.Add(carInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarInfo", new { id = carInfo.Id }, carInfo);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarInfo(int id)
        {
            var carInfo = await _context.Cars.FindAsync(id);
            if (carInfo == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(carInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarInfoExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}