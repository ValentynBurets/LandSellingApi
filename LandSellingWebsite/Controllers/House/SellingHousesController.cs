using AutoMapper;
using LandSellingWebsite.Data;
using LandSellingWebsite.Data.SortTypes;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.House;
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
        public async Task<ActionResult<IEnumerable<HouseViewModel>>> GetHouse([Required] bool sorted, SellingSortType? sortType)
        {
            var sellingHouses = await _context.Sellings.Include(Item => Item.Lot)
                                                       .Include(Item => Item.Lot.Images)
                                                       .Include(Item => Item.Lot.Houses)
                                                       .Include(Item => Item.Lot.Address)
                                                       
                                                       .ToListAsync();

            var sellingHouseViewModels = new List<HouseViewModel>();

            foreach(var house in sellingHouses)
            {
                var sellingViewModel = _mapper.Map<Selling, SellingViewModel>(house);
                sellingViewModel.Lot = _mapper.Map<Lot, LotViewModel>(house.Lot);
                sellingViewModel.Lot.Address
            }
            
            var lotIds = from coef in coefs
                         select coef.LotId;
            var lots = await _context.Lots.ToListAsync();

            var lotIds = from lot in lots
                         where(Item => Item.Contain(lot.Id != 
                         select lot.Id;

            var sellingHouses = (await _context.Houses
                                                   .Include(Item => Item.Lot)
                                                   .Include(Item => Item.Lot.Images)
                                                   .Include(Item => Item.Lot.Address)
                                                   .ToListAsync())
                                                   .Where(item => lotIds.Contains(item.LotId));

            var houseViewModels = new List<HouseViewModel>();

            foreach (var rentHouse in rentHouses)
            {
                var house = _mapper.Map<House, HouseViewModel>(rentHouse);
                house.Lot = _mapper.Map<Lot, LotViewModel>(rentHouse.Lot);

                if (rentHouse.Lot.Images != null)
                    house.Lot.Images = _mapper.Map<ICollection<Image>, ICollection<ImageViewModel>>(rentHouse.Lot.Images);
                if (rentHouse.Lot.Address != null)
                    house.Address = _mapper.Map<Address, AddressViewModel>(rentHouse.Lot.Address);

                houseViewModels.Add(house);
            }

            if (!sorted)
                return Ok(houseViewModels);
            else
            {
                if (sortType != null)
                {
                    if (sortType == RentSortType.City)
                    {
                        //Sort by city

                        houseViewModels.Sort((first, second) => first.Address.City.CompareTo(second.Address.City));

                        return houseViewModels;
                    }
                    if (sortType == RentSortType.Country)
                    {
                        //Sort by country
                        houseViewModels.Sort((first, second) => first.Address.Country.CompareTo(second.Address.Country));

                        return houseViewModels;
                    }
                    if (sortType == RentSortType.Id)
                    {
                        // Sort by Id
                        houseViewModels.Sort((first, second) => first.Id.CompareTo(second.Id));

                        return houseViewModels;
                    }
                }
            }

            return Ok(houseViewModels);
        }
    }
