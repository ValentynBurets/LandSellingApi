using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using AutoMapper;
using LandSellingWebsite.ViewModels.Lot.PriceCoef;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceCoefsController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public PriceCoefsController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PriceCoefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceCoef>>> GetPriceCoefs()
        {
            var priceCoefs = await _context.PriceCoefs.ToListAsync();
            var priceCoefViewModels = _mapper.Map<IEnumerable<PriceCoef>, IEnumerable<PriceCoefViewModel>>(priceCoefs);

            return Ok(priceCoefViewModels);
        }

        // GET: api/PriceCoefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceCoefViewModel>> GetPriceCoef(int id)
        {
            var priceCoef = await _context.PriceCoefs.FindAsync(id);

            if (priceCoef == null)
            {
                return NotFound();
            }

            var priceCoefViewModel = _mapper.Map<PriceCoef, PriceCoefViewModel>(priceCoef);

            return Ok(priceCoefViewModel);
        }

        // PUT: api/PriceCoefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceCoef(int id, PostPriceCoefViewModel priceCoefViewModel)
        {
            var priceCoef = _mapper.Map<PostPriceCoefViewModel, PriceCoef>(priceCoefViewModel);
            priceCoef.Id = id;

            _context.Entry(priceCoef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceCoefExists(id))
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

        //// POST: api/PriceCoefs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PriceCoefViewModel>> PostPriceCoef(PriceCoefViewModel PriceCoefViewModel)
        //{

        //    _context.PriceCoefs.Add(priceCoef);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPriceCoef", new { id = priceCoef.Id }, priceCoef);
        //}

        // DELETE: api/PriceCoefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriceCoef(int id)
        {
            var priceCoef = await _context.PriceCoefs.FindAsync(id);
            if (priceCoef == null)
            {
                return NotFound();
            }

            _context.PriceCoefs.Remove(priceCoef);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriceCoefExists(int id)
        {
            return _context.PriceCoefs.Any(e => e.Id == id);
        }
    }
}
