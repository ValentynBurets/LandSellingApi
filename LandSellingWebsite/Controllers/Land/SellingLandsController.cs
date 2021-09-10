using AutoMapper;
using LandSellingWebsite.Data.SortTypes;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.Address;
using LandSellingWebsite.ViewModels.Lot;
using LandSellingWebsite.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.Controllers.Land
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellingLandsController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public SellingLandsController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET: api/SellingLands? sroted = ""
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellingViewModel>>> GetLand([Required] bool sorted, SellingSortType? sortType)
        {
            var sellingLands = await _context.Sellings.Include(Item => Item.Lot)
                                                      .Include(Item => Item.Lot.Images)
                                                      .Include(Item => Item.Lot.Lands)
                                                      .Include(Item => Item.Lot.Address)
                                                      .Include(Item => Item.Manager)
                                                      .Include(Item => Item.Lot.Owner)
                                                      .Include(Item => Item.Lot.Bids)
                                                      .ToListAsync();
            
            var sellingLandViewModels = new List<SellingViewModel>();

            foreach (var land in sellingLands)
            {
                var sellingViewModel = _mapper.Map<Selling, SellingViewModel>(land);
                sellingViewModel.Lot = _mapper.Map<Lot, LotViewModel>(land.Lot);
                sellingViewModel.Lot.Address = _mapper.Map<Address, AddressViewModel>(land.Lot.Address);
                sellingViewModel.Manager = _mapper.Map<AppUser, SimpleUserViewModel>(land.Manager);
                sellingViewModel.Owner = _mapper.Map<AppUser, SimpleUserViewModel>(land.Lot.Owner);
                sellingViewModel.BidWinner = _mapper.Map<Bid, BidViewModel>(land.BidWinner);
                sellingViewModel.Lot.Images = _mapper.Map<ICollection<Image>, ICollection<ImageViewModel>>(land.Lot.Images);
                var bids = _mapper.Map<ICollection<Bid>, ICollection<BidViewModel>>(land.Lot.Bids);

                sellingViewModel.Bids = (ICollection<BidViewModel>)
                                        (from item in bids
                                         orderby item.Value descending
                                         select item);

                sellingLandViewModels.Add(sellingViewModel);
            }
        }
    }
}
