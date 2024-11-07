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
    public class CategorizedProductController : ControllerBase
    {
        private readonly ParasolDbContext _context;

        public CategorizedProductController(ParasolDbContext context)
        {
            _context = context;
        }

        // GET: api/CategorizedProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorizedProduct>>> GetCategorizedProduct()
        {
            return await _context.CategorizedProduct.ToListAsync();
        }

        // GET: api/CategorizedProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorizedProduct>> GetCategorizedProduct(int id)
        {
            var categorizedProduct = await _context.CategorizedProduct.FindAsync(id);

            if (categorizedProduct == null)
            {
                return NotFound();
            }

            return categorizedProduct;
        }

        // PUT: api/CategorizedProduct/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorizedProduct(int id, CategorizedProduct categorizedProduct)
        {
            if (id != categorizedProduct.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(categorizedProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorizedProductExists(id))
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

        // POST: api/CategorizedProduct
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategorizedProduct>> PostCategorizedProduct(CategorizedProduct categorizedProduct)
        {
            _context.CategorizedProduct.Add(categorizedProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategorizedProductExists(categorizedProduct.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategorizedProduct", new { id = categorizedProduct.ProductID }, categorizedProduct);
        }

        // DELETE: api/CategorizedProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorizedProduct(int id)
        {
            var categorizedProduct = await _context.CategorizedProduct.FindAsync(id);
            if (categorizedProduct == null)
            {
                return NotFound();
            }

            _context.CategorizedProduct.Remove(categorizedProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorizedProductExists(int id)
        {
            return _context.CategorizedProduct.Any(e => e.ProductID == id);
        }
    }
}
