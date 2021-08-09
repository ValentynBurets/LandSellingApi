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

                sellingViewModel.Owner = _mapper.Map<AppUser, UserViewModel>(selling.Lot.Owner);
                
                sellingViewModel.Customer = _mapper.Map<AppUser, UserViewModel>(selling.BidWinner.Bidder);

                sellingViewModel.Manager = _mapper.Map<AppUser, UserViewModel>(selling.Manager);

                //SellingStatusType status = await _context.SellingStatusTypes.FindAsync(selling.SellingStatusId);
                //if (status != null)
                //{
                //    sellingViewModel.SellingStatus = _mapper.Map<SellingStatusType, SellingStatusTypeViewModel>(status).Name;
                //}

                //Bid bid = await _context.Bids.FindAsync(selling.BidWinnerId);
                //if (bid != null)
                //{
                //    sellingViewModel.BidWinner = _mapper.Map<Bid, BidViewModel>(bid);
                //}

                //Lot lot = await _context.Lots.FindAsync(selling.LotId);
                //if (lot != null)
                //{
                //    sellingViewModel.Lot = _mapper.Map<Lot, LotViewModel>(lot);

                //    AppUser customer = await _context.AppUsers.FindAsync(lot.OwnerId);
                //    sellingViewModel.Customer = _mapper.Map<AppUser, UserViewModel>(customer);
                //}

                //AppUser manager = await _context.AppUsers.FindAsync(selling.ManagerId);
                //if (manager != null)
                //{
                //    sellingViewModel.Manager = _mapper.Map<AppUser, UserViewModel>(manager);
                //}
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

            var selling = await _context.Sellings.FindAsync(id);
            if (selling == null)
            {
                return NotFound();
            }

            SellingViewModel sellingViewModel = _mapper.Map<Selling, SellingViewModel>(selling);

            SellingStatusType status = await _context.SellingStatusTypes.FindAsync(selling.SellingStatusId);
            if (status != null)
            {
                sellingViewModel.SellingStatus = _mapper.Map<SellingStatusType, SellingStatusTypeViewModel>(status).Name;
            }

            Bid bid = await _context.Bids.FindAsync(selling.BidWinnerId);
            if (bid != null)
            {
                sellingViewModel.BidWinner = _mapper.Map<Bid, BidViewModel>(bid);
            }

            Lot lot = await _context.Lots.FindAsync(selling.LotId);
            if (lot != null)
            {
                sellingViewModel.Lot = _mapper.Map<Lot, LotViewModel>(lot);

                AppUser customer = await _context.AppUsers.FindAsync(lot.OwnerId);
                sellingViewModel.Customer = _mapper.Map<AppUser, UserViewModel>(customer);
            }
            
            AppUser manager = await _context.AppUsers.FindAsync(selling.ManagerId);
            if (manager != null)
            {
                sellingViewModel.Manager = _mapper.Map<AppUser, UserViewModel>(manager);
            }

            return sellingViewModel;
        }

        // PUT: api/Sellings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelling(int id, Selling selling)
        {
            if (id != selling.Id)
            {
                return BadRequest();
            }

            _context.Entry(selling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<Selling>> PostSelling(PostSellingViewModel sellingViewModel)
        {
            var selling = _mapper.Map<PostSellingViewModel, Selling>(sellingViewModel);

            _context.Sellings.Add(selling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelling", new { id = selling.Id }, selling);
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
