using AutoMapper;
using LandSellingWebsite.Data;
using LandSellingWebsite.Data.SortTypes;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.Address;
using LandSellingWebsite.ViewModels.House;
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

namespace LandSellingWebsite.Controllers.House
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellingHousesController : ControllerBase
    {

        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public SellingHousesController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Houses? sroted = ""
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellingViewModel>>> GetHouse([Required] bool sorted, SellingSortType? sortType)
        {
            var sellingHouses = await _context.Sellings.Include(Item => Item.Lot)
                                                       .Include(Item => Item.Lot.Images)
                                                       .Include(Item => Item.Lot.Houses)
                                                       .Include(Item => Item.Lot.Address)
                                                       .Include(Item => Item.Manager)
                                                       .Include(Item => Item.Lot.Owner)
                                                       .Include(Item => Item.Lot.Bids)
                                                       .ToListAsync();

            var sellingHouseViewModels = new List<SellingViewModel>();

            foreach (var house in sellingHouses)
            {
                var sellingViewModel = _mapper.Map<Selling, SellingViewModel>(house);
                sellingViewModel.Lot = _mapper.Map<Lot, LotViewModel>(house.Lot);
                sellingViewModel.Lot.Address = _mapper.Map<Address, AddressViewModel>(house.Lot.Address);
                sellingViewModel.Manager = _mapper.Map<AppUser, SimpleUserViewModel>(house.Manager);
                sellingViewModel.Owner = _mapper.Map<AppUser, SimpleUserViewModel>(house.Lot.Owner);
                sellingViewModel.BidWinner = _mapper.Map<Bid, BidViewModel>(house.BidWinner);
                sellingViewModel.Lot.Images = _mapper.Map<ICollection<Image>, ICollection<ImageViewModel>>(house.Lot.Images);
                var bids = _mapper.Map<ICollection<Bid>, ICollection<BidViewModel>>(house.Lot.Bids);

                sellingViewModel.Bids = (ICollection<BidViewModel>)
                                        (from item in bids
                                        orderby item.Value descending
                                        select item);

                sellingHouseViewModels.Add(sellingViewModel);
            }





            if (!sorted)
                return Ok(sellingHouseViewModels);
            else
            {
                if (sortType != null)
                {
                    if (sortType == SellingSortType.City)
                    {
                        //Sort by city

                        sellingHouseViewModels.Sort((first, second) => first.Lot.Address.City.CompareTo(second.Lot.Address.City));

                        return Ok(sellingHouseViewModels);
                    }
                    if (sortType == SellingSortType.Country)
                    {
                        //Sort by country
                        sellingHouseViewModels.Sort((first, second) => first.Lot.Address.Country.CompareTo(second.Lot.Address.Country));

                        return Ok(sellingHouseViewModels);
                    }
                    if (sortType == SellingSortType.Id)
                    {
                        // Sort by Id
                        sellingHouseViewModels.Sort((first, second) => first.Id.CompareTo(second.Id));

                        return Ok(sellingHouseViewModels);
                    }
                    if (sortType == SellingSortType.LowestBidFirst)
                    {
                        //Sort by price
                        var sortedSellings = from Item in sellingHouseViewModels
                                             orderby Item.Bids.ElementAt(0).Value
                                             select Item;

                        return Ok(sortedSellings);
                    }
                    if (sortType == SellingSortType.LowestPriceFirst)
                    {
                        //Sort by price
                        var sortedSellings = from Item in sellingHouseViewModels
                                             orderby Item.PriceBuyItNow
                                             select Item;

                        return Ok(sortedSellings);
                    }
                }
            }

            return Ok(sellingHouseViewModels);
        }
    }
}