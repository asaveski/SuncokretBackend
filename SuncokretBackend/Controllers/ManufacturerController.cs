using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuncokretBackend.DBContexts;
using SuncokretBackend.Models;

namespace SuncokretBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ParasolDbContext _context;

        public ManufacturerController(ParasolDbContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufecturer()
        {
            return await _context.Manufecturer.ToListAsync();
        }

        // GET: api/Manufacturer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
        {
            var manufacturer = await _context.Manufecturer.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }

        // PUT: api/Manufacturer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.ManufacturerID)
            {
                return BadRequest();
            }

            _context.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

        // POST: api/Manufacturer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        {
            _context.Manufecturer.Add(manufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturer", new { id = manufacturer.ManufacturerID }, manufacturer);
        }

        // DELETE: api/Manufacturer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await _context.Manufecturer.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufecturer.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufecturer.Any(e => e.ManufacturerID == id);
        }
    }
}
