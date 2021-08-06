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

namespace LandSellingWebsite.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RentStatusTypesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public RentStatusTypesController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RentStatusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentStatusType>>> GetRentStatusType()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rentStatusType = await _context.RentStatusTypes.ToListAsync();
            var rentStatusTypeModel = _mapper.Map<IEnumerable<RentStatusType>, IEnumerable<RentStatusTypeViewModel>>(rentStatusType);

            return Ok(rentStatusTypeModel);
        }

        // GET: api/RentStatusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentStatusType>> GetRentStatusType(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rentStatusType = await _context.RentStatusTypes.FindAsync(id);

            if (rentStatusType == null)
            {
                return NotFound();
            }

            var rentStatusTypeViewModel = _mapper.Map<RentStatusType, RentStatusTypeViewModel>(rentStatusType);

            return Ok(rentStatusTypeViewModel);
        }

        // PUT: api/RentStatusTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentStatusType(int id, RentStatusType rentStatusType)
        {
            if (id != rentStatusType.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentStatusType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentStatusTypeExists(id))
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

        // POST: api/RentStatusTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RentStatusType>> PostRentStatusType(RentStatusTypeViewModel rentStatusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RentStatusType createdRentStatusType = _mapper.Map<RentStatusTypeViewModel, RentStatusType>(rentStatusType);
            _context.RentStatusTypes.Add(createdRentStatusType);

            var createdRentStatusTypeViewModel = _mapper.Map<RentStatusType, RentStatusTypeViewModel>(createdRentStatusType);

            return Ok(createdRentStatusTypeViewModel);
        }

        // DELETE: api/RentStatusTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentStatusType>> DeleteRentStatusType(int id)
        {
            var rentStatusType = await _context.RentStatusTypes.FindAsync(id);
            if (rentStatusType == null)
            {
                return NotFound();
            }

            _context.RentStatusTypes.Remove(rentStatusType);
            await _context.SaveChangesAsync();

            return rentStatusType;
        }

        private bool RentStatusTypeExists(int id)
        {
            return _context.RentStatusTypes.Any(e => e.Id == id);
        }
    }
}
