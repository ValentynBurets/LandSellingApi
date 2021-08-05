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
    public class LotStatusTypesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;

        public LotStatusTypesController(LandSellingDBContext context)
        {
            _context = context;
        }

        // GET: api/LotStatusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LotStatusType>>> GetLotStatusType()
        {
            return await _context.LotStatusTypes.ToListAsync();
        }

        // GET: api/LotStatusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LotStatusType>> GetLotStatusType(int id)
        {
            var lotStatusType = await _context.LotStatusTypes.FindAsync(id);

            if (lotStatusType == null)
            {
                return NotFound();
            }

            return lotStatusType;
        }

        // PUT: api/LotStatusTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLotStatusType(int id, LotStatusType lotStatusType)
        {
            if (id != lotStatusType.Id)
            {
                return BadRequest();
            }

            _context.Entry(lotStatusType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LotStatusTypeExists(id))
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

        // POST: api/LotStatusTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LotStatusType>> PostLotStatusType(LotStatusType lotStatusType)
        {
            _context.LotStatusTypes.Add(lotStatusType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLotStatusType", new { id = lotStatusType.Id }, lotStatusType);
        }

        // DELETE: api/LotStatusTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LotStatusType>> DeleteLotStatusType(int id)
        {
            var lotStatusType = await _context.LotStatusTypes.FindAsync(id);
            if (lotStatusType == null)
            {
                return NotFound();
            }

            _context.LotStatusTypes.Remove(lotStatusType);
            await _context.SaveChangesAsync();

            return lotStatusType;
        }

        private bool LotStatusTypeExists(int id)
        {
            return _context.LotStatusTypes.Any(e => e.Id == id);
        }
    }
}
