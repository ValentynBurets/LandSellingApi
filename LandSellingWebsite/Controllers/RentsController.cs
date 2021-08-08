using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using AutoMapper;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.Rent;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public RentsController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Rents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentViewModel>>> GetRent()
        {
            var rents = await _context.Rents.ToListAsync();
            var rentViewModels = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentViewModel>>(rents);



            return Ok(rentViewModels); 
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentViewModel>> GetRent(int id)
        {
            var rent = await _context.Rents.FindAsync(id);

            if (rent == null)
            {
                return NotFound();
            }

            var rentViewModel = _mapper.Map<Rent, RentViewModel>(rent);

            return rentViewModel;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent(int id, PostRentViewModel postRent)
        {
            Rent rent = _mapper.Map<PostRentViewModel, Rent>(postRent);

            _context.Entry(rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostRentViewModel>> PostRent(PostRentViewModel postRent)
        {
            var rent = _mapper.Map<PostRentViewModel, Rent>(postRent);
            _context.Rents.Add(rent);
            await _context.SaveChangesAsync();

            return postRent;
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rent>> DeleteRent(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();

            return rent;
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.Id == id);
        }
    }
}
