using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using Microsoft.Data.SqlClient;
using LandSellingWebsite.ViewModels.Land;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandsController : ControllerBase
    {
        private readonly LandSellingDBContext _context;

        public LandsController(LandSellingDBContext context)
        {
            _context = context;
        }

        // GET: api/Lands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VLand>>> GetLand()
        {
            return await _context.VLands.ToListAsync();
        }

        // GET: api/Lands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VLand>> GetLand(int id)
        {
            var land = await _context.VLands.FindAsync(id);

            if (land == null)
            {
                return NotFound();
            }

            return land;
        }

        // PUT: api/Lands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLand(int id, VLand land)
        {
            if (id != land.Id)
            {
                return BadRequest();
            }

            //_context.AddLand(land);
            _context.Entry(land).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandExists(id))
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

        // POST: api/Lands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VLand>> PostLand(PostLandViewModel land)
        {


            //_context.Lands
            //    .FromSql($"AddLand {land.Id}")
            //_context.AddLand(land);
            //string params = $"'{land.Country}' '{land.Region}' '{land.City}' '{land.Street}' '{land.Building}' '{land.Latitude}' '{land.Longitude}' '{land.OwnerId}' '{land.Square}' '{land.Description}'";
            //SqlParameter pCountry = new SqlParameter("@Country", land.Country);
            //SqlParameter pRegion = new SqlParameter("@Region", land.Region);
            //SqlParameter pCity = new SqlParameter("@City", land.City);
            //SqlParameter pStreet = new SqlParameter("@Street", land.Street);
            //SqlParameter pBuilding = new SqlParameter("@Building", land.Building);
            //SqlParameter pLatitude = new SqlParameter("@Latitude", land.Latitude);
            //SqlParameter pLongitude = new SqlParameter("@Longitude", land.Longitude);
            //SqlParameter pOwnerId = new SqlParameter("@OwnerId", land.OwnerId);
            //SqlParameter pSquare = new SqlParameter("@Square", land.Square);
            //SqlParameter pDescription = new SqlParameter("@Description", land.Description);
            //SqlParameter pImageUrl = new SqlParameter("@ImageUrl", land.ImageUrl);

            _context.Lands.FromSqlRaw("EXECUTE AddLand " +
                                            $"{land.Country} " +
                                            $"{land.Region} " +
                                            $"{land.City} " +
                                            $"{land.Street} " +
                                            $"{land.Building} " +
                                            $"{land.Latitude} " +
                                            $"{land.Longitude} " +
                                            $"{land.OwnerId} " +
                                            $"{land.Square} " +
                                            $"{land.Description} ",
                                            $"{land.ImageUrl} ");

            return CreatedAtAction("GetLand", new { ImageUrl = land.ImageUrl }, land);

            //_context.Lands.FromSqlRaw("EXECUTE AddLand " +
            //                               "@Country " +
            //                               "@Region " +
            //                               "@City " +
            //                               "@Street " +
            //                               "@Building " +
            //                               "@Latitude " +
            //                               "@Longitude " +
            //                               "@OwnerId " +
            //                               "@Square " +
            //                               "@Description",
            //                               pCountry,
            //                               pRegion,
            //                               pCity,
            //                               pStreet,
            //                               pBuilding,
            //                               pLatitude,
            //                               pLongitude,
            //                               pOwnerId,
            //                               pSquare,
            //                               pDescription,
            //                               pImageUrl);

            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetLand", new { id = land.Id }, land);
        }

        // DELETE: api/Lands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Land>> DeleteLand(int id)
        {
            var land = await _context.Lands.FindAsync(id);
            if (land == null)
            {
                return NotFound();
            }

            _context.Lands.Remove(land);
            await _context.SaveChangesAsync();

            return land;
        }

        private bool LandExists(int id)
        {
            return _context.Lands.Any(e => e.Id == id);
        }
    }
}
