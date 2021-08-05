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
    public class DurationTypesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;

        public DurationTypesController(LandSellingDBContext context)
        {
            _context = context;
        }

        // GET: api/DurationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DurationType>>> GetDurationType()
        {
            return await _context.DurationTypes.ToListAsync();
        }

        // GET: api/DurationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DurationType>> GetDurationType(int id)
        {
            var durationType = await _context.DurationTypes.FindAsync(id);

            if (durationType == null)
            {
                return NotFound();
            }

            return durationType;
        }

        // PUT: api/DurationTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDurationType(int id, DurationType durationType)
        {
            if (id != durationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(durationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DurationTypeExists(id))
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

        // POST: api/DurationTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DurationType>> PostDurationType(DurationType durationType)
        {
            _context.DurationTypes.Add(durationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDurationType", new { id = durationType.Id }, durationType);
        }

        // DELETE: api/DurationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DurationType>> DeleteDurationType(int id)
        {
            var durationType = await _context.DurationTypes.FindAsync(id);
            if (durationType == null)
            {
                return NotFound();
            }

            _context.DurationTypes.Remove(durationType);
            await _context.SaveChangesAsync();

            return durationType;
        }

        private bool DurationTypeExists(int id)
        {
            return _context.DurationTypes.Any(e => e.Id == id);
        }
    }
}
