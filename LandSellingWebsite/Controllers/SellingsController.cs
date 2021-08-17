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
using LandSellingWebsite.ViewModels.User;
using LandSellingWebsite.ViewModels.Selling;

namespace LandSellingWebsite.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SellingsController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public SellingsController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sellings
        [HttpGet]
        public async Task<IEnumerable<SellingViewModel>> GetSelling()
        {
            ICollection<Selling> sellings = await _context.Sellings
                                                          .Include(Item => Item.Lot)
                                                              .ThenInclude(Lot => Lot.Owner)
                                                          .Include(Item => Item.Manager)
                                                              .ThenInclude(Manager => Manager.Role)
                                                          .Include(Item => Item.BidWinner)
                                                              .ThenInclude(BidWinner => BidWinner.Bidder)
                                                          .Include(Item => Item.SellingStatus)
                                                          .ToListAsync();
            if (sellings == null)
            {
                return (IEnumerable<SellingViewModel>)NotFound();
            }

            ICollection<SellingViewModel> sellingsViewModels = new List<SellingViewModel>();

            foreach (var selling in sellings)
            {
                //selling.Lot

                SellingViewModel sellingViewModel = _mapper.Map<Selling, SellingViewModel>(selling);

                sellingViewModel.Lot = _mapper.Map<Lot, LotViewModel>(selling.Lot);

                sellingViewModel.Owner = _mapper.Map<AppUser, SimpleUserViewModel>(selling.Lot.Owner);

                //sellingViewModel.Manager = _mapper.Map<AppUser, SimpleUserViewModel>(selling.Manager);

                if (selling.BidWinner != null)
                    sellingViewModel.Customer = _mapper.Map<AppUser, SimpleUserViewModel>(selling.BidWinner.Bidder);

               
                sellingsViewModels.Add(sellingViewModel);
            }

            return sellingsViewModels;
        }

        // GET: api/Sellings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellingViewModel>> GetSelling(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Selling selling = await _context.Sellings.Include(Item => Item.Lot)
                .ThenInclude(Lot => Lot.Owner)
                .Include(Item => Item.Manager)
                .ThenInclude(Manager => Manager.Role)
                .Include(Item => Item.BidWinner)
                .ThenInclude(BidWinner => BidWinner.Bidder)
                .Include(Item => Item.SellingStatus)
                .Where(Item => Item.Id == id)
                .FirstAsync();

            if (selling == null)
            {
                return NotFound();
            }
            SellingViewModel sellingViewModel = _mapper.Map<Selling, SellingViewModel>(selling);

            sellingViewModel.Lot = _mapper.Map<Lot, LotViewModel>(selling.Lot);

            sellingViewModel.Owner = _mapper.Map<AppUser, SimpleUserViewModel>(selling.Lot.Owner);

            if (selling.BidWinner != null)
                sellingViewModel.Customer = _mapper.Map<AppUser, SimpleUserViewModel>(selling.BidWinner.Bidder);

            sellingViewModel.Manager = _mapper.Map<AppUser, SimpleUserViewModel>(selling.Manager);

            return sellingViewModel;
        }

        // PUT: api/Sellings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelling(int id, PostSellingViewModel postSelling)
        {
            var selling = _mapper.Map<PostSellingViewModel, SellingViewModel>(postSelling);
            selling.Id = id;
            
            _context.Entry(selling).State = EntityState.Modified;

            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync(
              $"EXECUTE AddSelling {postSelling.LotId}, {postSelling.ManagerId}, {postSelling.MinPrice}, {postSelling.PriceBuyItNow}");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellingExists(id))
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

        // POST: api/Sellings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Selling>> PostSelling(PostSellingViewModel postSelling)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
              $"EXECUTE AddSelling {postSelling.LotId}, {postSelling.ManagerId}, {postSelling.MinPrice}, {postSelling.PriceBuyItNow}");

            return CreatedAtAction("GetSelling", new { LotId = postSelling.LotId }, postSelling);
        }

        // DELETE: api/Sellings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Selling>> DeleteSelling(int id)
        {
            var selling = await _context.Sellings.FindAsync(id);
            if (selling == null)
            {
                return NotFound();
            }

            _context.Sellings.Remove(selling);
            await _context.SaveChangesAsync();

            return selling;
        }

        private bool SellingExists(int id)
        {
            return _context.Sellings.Any(e => e.Id == id);
        }
    }
}
