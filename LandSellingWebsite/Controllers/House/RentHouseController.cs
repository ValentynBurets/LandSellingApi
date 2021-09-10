using AutoMapper;
using LandSellingWebsite.Data;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.Address;
using LandSellingWebsite.ViewModels.House;
using LandSellingWebsite.ViewModels.Lot;
using LandSellingWebsite.ViewModels.Lot.PriceCoef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentHouseController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public RentHouseController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RentHouses? sroted = ""
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseViewModel>>> GetHouse([Required] bool sorted, RentSortType? sortType)
        {

            var coefs = await _context.PriceCoefs.ToListAsync();
            var lotIds = from coef in coefs
                         select coef.LotId;

            var rentHouses = (await _context.Houses
                                                   .Include(Item => Item.Lot)
                                                   .Include(Item => Item.Lot.Images)
                                                   .Include(Item => Item.Lot.Address)
                                                   .ToListAsync())
                                                   .Where(item => lotIds.Contains(item.LotId));
            
            var houseViewModels = new List<HouseViewModel>();

            foreach(var rentHouse in rentHouses)
            {
                var house = _mapper.Map<Models.House, HouseViewModel>(rentHouse);
                house.Lot = _mapper.Map<Lot, LotViewModel>(rentHouse.Lot);

                if (rentHouse.Lot.Images != null)
                    house.Lot.Images = _mapper.Map<ICollection<Image>, ICollection<ImageViewModel>>(rentHouse.Lot.Images);
                if (rentHouse.Lot.Address != null)
                    house.Lot.Address = _mapper.Map<Address, AddressViewModel>(rentHouse.Lot.Address);

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

        //// POST: api/Houses
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<HouseViewModel>> PostRentHouse(PostRentHouseViewModel posthouse)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var createdHouse = _mapper.Map<PostRentHouseViewModel, House>(posthouse);
            
        //    var priceCoef = _mapper.Map<ICollection<PriceCoefViewModel>, ICollection<PriceCoef>>(posthouse.PriceCoefs);
        //    _context.PriceCoefs.AddRange(priceCoef);

        //    var lot = _mapper.Map<LotViewModel, Lot>(posthouse.Lot); 
            
        //    var address = _mapper.Map<AddressViewModel, Address>(posthouse.Address);
        //    _context.Addresses.Add(address);

        //    lot.Address = address;
        //    _context.Lots.Add(lot);

        //    createdHouse.Lot = lot;

        //    _context.Lots.Add(lot);
        //    await _context.SaveChangesAsync();

        //    HouseViewModel house = _mapper.Map<House, HouseViewModel>(createdHouse);

        //    return Ok(house);
        //}
    }
}

