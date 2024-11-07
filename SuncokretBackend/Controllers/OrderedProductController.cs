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
    public class OrderedProductController : ControllerBase
    {
        private readonly ParasolDbContext _context;

        public OrderedProductController(ParasolDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderedProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderedProduct>>> GetOrderedProduct()
        {
            return await _context.OrderedProduct.ToListAsync();
        }

        // GET: api/OrderedProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderedProduct>> GetOrderedProduct(int id)
        {
            var orderedProduct = await _context.OrderedProduct.FindAsync(id);

            if (orderedProduct == null)
            {
                return NotFound();
            }

            return orderedProduct;
        }

        // PUT: api/OrderedProduct/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderedProduct(int id, OrderedProduct orderedProduct)
        {
            if (id != orderedProduct.OrderedProductID)
            {
                return BadRequest();
            }

            _context.Entry(orderedProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderedProductExists(id))
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

        // POST: api/OrderedProduct
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderedProduct>> PostOrderedProduct(OrderedProduct orderedProduct)
        {
            _context.OrderedProduct.Add(orderedProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderedProduct", new { id = orderedProduct.OrderedProductID }, orderedProduct);
        }

        // DELETE: api/OrderedProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderedProduct(int id)
        {
            var orderedProduct = await _context.OrderedProduct.FindAsync(id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            _context.OrderedProduct.Remove(orderedProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderedProductExists(int id)
        {
            return _context.OrderedProduct.Any(e => e.OrderedProductID == id);
        }
    }
}
