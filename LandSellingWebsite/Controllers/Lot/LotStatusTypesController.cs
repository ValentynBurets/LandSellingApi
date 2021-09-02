using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using AutoMapper;
using LandSellingWebsite.ViewModels.LotStatusType;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotStatusTypesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public LotStatusTypesController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LotStatusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LotStatusTypeViewModel>>> GetLotStatusType()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lotStatusTypes = await _context.LotStatusTypes.ToListAsync();
            var lotStatusTypeViewModels = _mapper.Map<IEnumerable<LotStatusType>, IEnumerable<LotStatusTypeViewModel>>(lotStatusTypes);

            return Ok(lotStatusTypeViewModels);

        }

        // GET: api/LotStatusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LotStatusTypeViewModel>> GetLotStatusType(int id)
        {
            var lotStatusType = await _context.LotStatusTypes.FindAsync(id);

            if (lotStatusType == null)
            {
                return NotFound();
            }

            var lotStatusTypeViewModel = _mapper.Map<LotStatusType, LotStatusTypeViewModel>(lotStatusType);

            return lotStatusTypeViewModel;
        }

        // PUT: api/LotStatusTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLotStatusType(int id, PostLotStatusTypeViewModel lotStatusTypeViewModel)
        {
            var lotStatusType = _mapper.Map<PostLotStatusTypeViewModel, LotStatusType>(lotStatusTypeViewModel);
            lotStatusType.Id = id;

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
        public async Task<ActionResult<LotStatusTypeViewModel>> PostLotStatusType(PostLotStatusTypeViewModel postLotStatusType)
        {
            LotStatusType lotStatusType = _mapper.Map<PostLotStatusTypeViewModel, LotStatusType>(postLotStatusType);

            _context.LotStatusTypes.Add(lotStatusType);
            
            await _context.SaveChangesAsync();

            var lotStatusTypeViewModel = _mapper.Map<LotStatusType, LotStatusTypeViewModel>(lotStatusType);

            return Ok(lotStatusTypeViewModel);
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
