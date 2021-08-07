using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.ViewModels;
using AutoMapper;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels.Bid;

namespace LandSellingWebsite.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public BidController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Bids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidViewModel>>> GetBid()
        {
            var bids = await _context.Bids.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Bid>, IEnumerable<BidViewModel>>(bids));
        }

        // GET: api/Bid/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bid>> GetBid(int id)
        {
            var bid = await _context.Bids.FindAsync(id);

            if (bid == null)
            {
                return NotFound();
            }

            return bid;
        }

        // PUT: api/Bid/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBid(int id, PostBidViewModel putBid)
        {
            Bid bid = _mapper.Map<PostBidViewModel, Bid>(putBid);
            bid.Id = id;

            if (id != bid.Id)
            {
                return BadRequest();
            }

            _context.Entry(bid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(id))
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

        // POST: api/Bid
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bid>> PostBid(PostBidViewModel postBid)
        {
            Bid bid = _mapper.Map<PostBidViewModel, Bid>(postBid);

            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostBidViewModel", new { id = bid.Id }, bid);
        }

        // DELETE: api/Bid/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBid(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BidExists(int id)
        {
            return _context.Bids.Any(e => e.Id == id);
        }
    }
}
