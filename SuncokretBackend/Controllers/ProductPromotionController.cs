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
    public class ProductPromotionController : ControllerBase
    {
        private readonly ParasolDbContext _context;

        public ProductPromotionController(ParasolDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductPromotion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPromotion>>> GetProductPromotion()
        {
            return await _context.ProductPromotion.ToListAsync();
        }

        // GET: api/ProductPromotion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPromotion>> GetProductPromotion(int id)
        {
            var productPromotion = await _context.ProductPromotion.FindAsync(id);

            if (productPromotion == null)
            {
                return NotFound();
            }

            return productPromotion;
        }

        // PUT: api/ProductPromotion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPromotion(int id, ProductPromotion productPromotion)
        {
            if (id != productPromotion.ProductPromotionID)
            {
                return BadRequest();
            }

            _context.Entry(productPromotion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPromotionExists(id))
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

        // POST: api/ProductPromotion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductPromotion>> PostProductPromotion(ProductPromotion productPromotion)
        {
            _context.ProductPromotion.Add(productPromotion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductPromotion", new { id = productPromotion.ProductPromotionID }, productPromotion);
        }

        // DELETE: api/ProductPromotion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPromotion(int id)
        {
            var productPromotion = await _context.ProductPromotion.FindAsync(id);
            if (productPromotion == null)
            {
                return NotFound();
            }

            _context.ProductPromotion.Remove(productPromotion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductPromotionExists(int id)
        {
            return _context.ProductPromotion.Any(e => e.ProductPromotionID == id);
        }
    }
}
