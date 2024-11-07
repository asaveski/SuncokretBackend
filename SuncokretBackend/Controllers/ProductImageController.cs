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
    public class ProductImageController : ControllerBase
    {
        private readonly ParasolDbContext _context;

        public ProductImageController(ParasolDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductImage>>> GetProductImage()
        {
            return await _context.ProductImage.ToListAsync();
        }

        // GET: api/ProductImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImage>> GetProductImage(int id)
        {
            var productImage = await _context.ProductImage.FindAsync(id);

            if (productImage == null)
            {
                return NotFound();
            }

            return productImage;
        }

        // PUT: api/ProductImage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductImage(int id, ProductImage productImage)
        {
            if (id != productImage.ProductImageID)
            {
                return BadRequest();
            }

            _context.Entry(productImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductImageExists(id))
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

        // POST: api/ProductImage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductImage>> PostProductImage(ProductImage productImage)
        {
            _context.ProductImage.Add(productImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductImage", new { id = productImage.ProductImageID }, productImage);
        }

        // DELETE: api/ProductImage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var productImage = await _context.ProductImage.FindAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }

            _context.ProductImage.Remove(productImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductImageExists(int id)
        {
            return _context.ProductImage.Any(e => e.ProductImageID == id);
        }
    }
}
