using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellingsController : ControllerBase
    {
        private readonly LandSellingDBContext _context;

        public SellingsController(LandSellingDBContext context)
        {
            _context = context;
        }

        // GET: api/Sellings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Selling>>> GetSelling()
        {
            return await _context.Sellings.ToListAsync();
        }

        // GET: api/Sellings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Selling>> GetSelling(int id)
        {
            var selling = await _context.Sellings.FindAsync(id);

            if (selling == null)
            {
                return NotFound();
            }

            return selling;
        }

        // PUT: api/Sellings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelling(int id, Selling selling)
        {
            if (id != selling.Id)
            {
                return BadRequest();
            }

            _context.Entry(selling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellingExists(id))
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

        // POST: api/Sellings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Selling>> PostSelling(Selling selling)
        {
            _context.Sellings.Add(selling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelling", new { id = selling.Id }, selling);
        }

        // DELETE: api/Sellings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Selling>> DeleteSelling(int id)
        {
            var selling = await _context.Sellings.FindAsync(id);
            if (selling == null)
            {
                return NotFound();
            }

            _context.Sellings.Remove(selling);
            await _context.SaveChangesAsync();

            return selling;
        }

        private bool SellingExists(int id)
        {
            return _context.Sellings.Any(e => e.Id == id);
        }
    }
}
