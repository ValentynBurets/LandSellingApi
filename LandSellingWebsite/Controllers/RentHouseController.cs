using AutoMapper;
using LandSellingWebsite.Models;
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
        private readonly IMapper _mapping;

        public RentHouseController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapping = mapper;
        }

        // GET: api/Houses? sroted = ""
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VHouse>>> GetHouse([Required] bool sorted, int? sortType)
        {
            if (!sorted)
                return await _context.VHouses.ToListAsync();
            else
            {
                if (sortType != null)
                {
                    if (sortType == 1)
                    {
                        //Sort by city
                        var houses = await _context.VHouses.ToListAsync();
                        houses.Sort((first, second) => first.City.CompareTo(second.City));

                        return houses;
                    }
                    if (sortType == 2)
                    {
                        //Sort by country
                        var houses = await _context.VHouses.ToListAsync();
                        houses.Sort((first, second) => first.Country.CompareTo(second.Country));

                        return houses;
                    }
                    else
                    {
                        // Sort by Id
                        var houses = await _context.VHouses.ToListAsync();
                        houses.Sort((first, second) => first.Id.CompareTo(second.Id));

                        return houses;
                    }
                }

            }
            return null;
        }
    }
}

