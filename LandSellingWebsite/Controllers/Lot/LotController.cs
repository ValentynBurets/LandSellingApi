using AutoMapper;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LandSellingDBContext _context;

        public LotController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get: api/Lots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LotViewModel>>> GetLots()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lots = await _context.Lots.ToListAsync();
            var lotsViewModel = _mapper.Map<IEnumerable<Lot>, IEnumerable<LotViewModel>>(lots);

            return Ok(lotsViewModel);
        }

        //GET: api/Lots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LotViewModel>> GetLot(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lot = await _context.Lots.FindAsync(id);
            if(lot == null)
            {
                return NotFound();
            }

            var lotViewModel = _mapper.Map<Lot, LotViewModel>(lot);

            return Ok(lotViewModel);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutLot(int id, LotViewModel lotViewModel)
        {
            Lot lot = _mapper.Map<LotViewModel, Lot>(lotViewModel);

            if(id != lot.Id)
            {
                return BadRequest();
            }

            _context.Entry(lot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!LotExists(id))
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

        //POST: api/Lotss
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LotViewModel>> PostCar(LotViewModel lot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Lot createdLot = _mapper.Map<LotViewModel, Lot>(lot);
            _context.Lots.Add(createdLot);
            await _context.SaveChangesAsync();

            var createdLotViewModel = _mapper.Map<Lot, LotViewModel>(createdLot);

            return Ok(createdLotViewModel);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lot>> DeleteLot(int id)
        {
            var lot = await _context.Lots.FindAsync(id);
            if (!LotExists(id) || lot == null)
            {
                return NotFound();
            }

            _context.Lots.Remove(lot);

            return NoContent();
        }

        private bool LotExists(int id)
        {
            return _context.Lots.Any(e => e.Id == id);
        }
    }
}
