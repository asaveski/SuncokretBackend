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
    public class CartStatusController : ControllerBase
    {
        private readonly ParasolDbContext _context;

        public CartStatusController(ParasolDbContext context)
        {
            _context = context;
        }

        // GET: api/CartStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartStatus>>> GetCartStatus()
        {
            return await _context.CartStatus.ToListAsync();
        }

        // GET: api/CartStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartStatus>> GetCartStatus(int id)
        {
            var cartStatus = await _context.CartStatus.FindAsync(id);

            if (cartStatus == null)
            {
                return NotFound();
            }

            return cartStatus;
        }

        // PUT: api/CartStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartStatus(int id, CartStatus cartStatus)
        {
            if (id != cartStatus.CartStatusID)
            {
                return BadRequest();
            }

            _context.Entry(cartStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartStatusExists(id))
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

        // POST: api/CartStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartStatus>> PostCartStatus(CartStatus cartStatus)
        {
            _context.CartStatus.Add(cartStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartStatus", new { id = cartStatus.CartStatusID }, cartStatus);
        }

        // DELETE: api/CartStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartStatus(int id)
        {
            var cartStatus = await _context.CartStatus.FindAsync(id);
            if (cartStatus == null)
            {
                return NotFound();
            }

            _context.CartStatus.Remove(cartStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartStatusExists(int id)
        {
            return _context.CartStatus.Any(e => e.CartStatusID == id);
        }
    }
}
