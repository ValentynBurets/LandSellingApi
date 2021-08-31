using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels.House;
using AutoMapper;
using LandSellingWebsite.ViewModels;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapping;

        public HousesController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapping = mapper;
        }

        // GET: api/Houses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VHouse>>> GetHouse()
        //{
        //    return await _context.VHouses.ToListAsync();
        //}

        //// GET: api/Houses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VHouse>>> GetSortByCity()
        //{
        //    var houses = await _context.VHouses.ToListAsync();
        //    houses.Sort((first, second) => first.City.CompareTo(second.City));

        //    return houses;
        //}

        //// GET: api/Houses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VHouse>>> GetSortByCountry()
        //{
        //    var houses = await _context.VHouses.ToListAsync();
        //    houses.Sort((first, second) => first.Country.CompareTo(second.Country));

        //    return houses;
        //}


        //// GET: api/Houses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VHouse>>> GetSortById()
        //{
        //    var houses = await _context.VHouses.ToListAsync();
        //    houses.Sort((first, second) => first.Id.CompareTo(second.Id));

        //    return houses;
        //}

        //// GET: api/Houses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<House>>> GetSortByMinPricePerDay()
        //{
        //    var houses = await _context.Houses.ToListAsync();
        //    houses.Sort((first, second) => first..CompareTo(second.Id));

        //    return houses;
        //}


        // GET: api/Houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VHouse>> GetHouse(int id)
        {
            var house = await _context.VHouses.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return house;
        }

        // PUT: api/Houses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id,  PostHouseViewModel house)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXECUTE AddHouse {house.Country}, {house.Region}, {house.City}, {house.Street}, {house.Building}, {house.Latitude}, {house.Longitude}, {house.OwnerId}, {house.Square}, {house.Description}, {house.Rooms}, {house.Storeys}, {house.Person}, {house.Parking}, {house.Furniture}, {house.ImageUrl}");

            return NoContent();
        }

        // POST: api/Houses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HouseViewModel>> PostHouse(PostHouseViewModel posthouse)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXECUTE AddHouse {posthouse.Country}, {posthouse.Region}, {posthouse.City}, {posthouse.Street}, {posthouse.Building}, {posthouse.Latitude}, {posthouse.Longitude}, {posthouse.OwnerId}, {posthouse.Square}, {posthouse.Description}, {posthouse.Rooms}, {posthouse.Storeys}, {posthouse.Person}, {posthouse.Parking}, {posthouse.Furniture}");

            var houses = await _context.Houses.Include(Item => Item.Lot).ToListAsync();

            var houseViewModels = new List<HouseViewModel>();
            
            foreach(var house in houses)
            {
                var houseViewModel = _mapping.Map<House, HouseViewModel>(house);
                houseViewModel.Lot = _mapping.Map<Lot, LotViewModel>(house.Lot);
                houseViewModels.Add(houseViewModel);
            }

            return Ok(houseViewModels);
        }

        // DELETE: api/Houses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> DeleteHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return house;
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }
    }
}
