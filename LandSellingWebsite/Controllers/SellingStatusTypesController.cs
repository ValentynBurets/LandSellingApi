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
    public class SellingStatusTypesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;

        public SellingStatusTypesController(LandSellingDBContext context)
        {
            _context = context;
        }

        // GET: api/SellingStatusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellingStatusType>>> GetSellingStatusType()
        {
            return await _context.SellingStatusTypes.ToListAsync();
        }

        // GET: api/SellingStatusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellingStatusType>> GetSellingStatusType(int id)
        {
            var sellingStatusType = await _context.SellingStatusTypes.FindAsync(id);

            if (sellingStatusType == null)
            {
                return NotFound();
            }

            return sellingStatusType;
        }

        // PUT: api/SellingStatusTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellingStatusType(int id, SellingStatusType sellingStatusType)
        {
            if (id != sellingStatusType.Id)
            {
                return BadRequest();
            }

            _context.Entry(sellingStatusType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellingStatusTypeExists(id))
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

        // POST: api/SellingStatusTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SellingStatusType>> PostSellingStatusType(SellingStatusType sellingStatusType)
        {
            _context.SellingStatusTypes.Add(sellingStatusType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSellingStatusType", new { id = sellingStatusType.Id }, sellingStatusType);
        }

        // DELETE: api/SellingStatusTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SellingStatusType>> DeleteSellingStatusType(int id)
        {
            var sellingStatusType = await _context.SellingStatusTypes.FindAsync(id);
            if (sellingStatusType == null)
            {
                return NotFound();
            }

            _context.SellingStatusTypes.Remove(sellingStatusType);
            await _context.SaveChangesAsync();

            return sellingStatusType;
        }

        private bool SellingStatusTypeExists(int id)
        {
            return _context.SellingStatusTypes.Any(e => e.Id == id);
        }
    }
}
