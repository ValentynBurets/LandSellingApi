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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VHouse>>> GetHouse()
        {
            return await _context.VHouses.ToListAsync();
        }

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
        public async Task<IActionResult> PutHouse(int id, HouseViewModel houseViewModel)
        {
            var house = _mapping.Map<HouseViewModel, House>(houseViewModel);
            house.Id = id;
            var lot = _mapping.Map<LotViewModel, Lot>(houseViewModel.Lot);
            house.LotId = lot.Id;

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
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

        // POST: api/Houses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostHouseViewModel>> PostHouse(PostHouseViewModel house)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXECUTE AddHouse {house.Country}, {house.Region}, {house.City}, {house.Street}, {house.Building}, {house.Latitude}, {house.Longitude}, {house.OwnerId}, {house.Square}, {house.Description}, {house.Rooms}, {house.Storeys}, {house.Person}, {house.Parking}, {house.Furniture}, {house.ImageUrl}");

            return house;
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
