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
    [Route("api/[controller]")]
    [ApiController]
    public class SellingStatusTypesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public SellingStatusTypesController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SellingStatusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellingStatusTypeViewModel>>> GetSellingStatusType()
        {
            var statuses = await _context.SellingStatusTypes.ToListAsync();
            var statusViewModels = _mapper.Map<IEnumerable<SellingStatusType>, IEnumerable<SellingStatusTypeViewModel>>(statuses);

            return Ok(statusViewModels);
        }

        // GET: api/SellingStatusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellingStatusTypeViewModel>> GetSellingStatusType(int id)
        {
            var sellingStatusType = await _context.SellingStatusTypes.FindAsync(id);

            if (sellingStatusType == null)
            {
                return NotFound();
            }

            var sellingStatusViewModel = _mapper.Map<SellingStatusType, SellingStatusTypeViewModel>(sellingStatusType);

            return Ok(sellingStatusViewModel);
        }

        // PUT: api/SellingStatusTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellingStatusType(int id, SellingStatusTypeViewModel sellingStatusTypeViewModel)
        {
            if (id != sellingStatusTypeViewModel.Id)
            {
                return BadRequest();
            }

            var sellingStatusType = _mapper.Map<SellingStatusTypeViewModel, SellingStatusType>(sellingStatusTypeViewModel);

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
        public async Task<ActionResult<SellingStatusType>> PostSellingStatusType(SellingStatusTypeViewModel sellingStatusTypeViewModel)
        {
            var sellingStatusType = _mapper.Map<SellingStatusTypeViewModel, SellingStatusType>(sellingStatusTypeViewModel);
            
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
