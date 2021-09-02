using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using AutoMapper;
using LandSellingWebsite.ViewModels.Lot.Favorite;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public FavoritesController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Favorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteViewModel>>> GetFavorites()
        {
            var favorites = await _context.Favorites.ToListAsync();
            var favoriteViewModels = _mapper.Map<IEnumerable<Favorite>, IEnumerable<FavoriteViewModel>>(favorites);

            return Ok(favoriteViewModels);
        }

        // GET: api/Favorites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            var favoriteViewModel = _mapper.Map<Favorite, FavoriteViewModel>(favorite);

            return Ok(favoriteViewModel);
        }

        // PUT: api/Favorites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, PostFavoriteViewModel postFavoriteViewModel)
        {
            var favorite = _mapper.Map<PostFavoriteViewModel, Favorite>(postFavoriteViewModel);
            
            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/Favorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteViewModel>> PostFavorite(PostFavoriteViewModel postFavoriteViewModel)
        {
            var favorite = _mapper.Map<PostFavoriteViewModel, Favorite>(postFavoriteViewModel);

            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            var favoriteViewModel = _mapper.Map<Favorite, FavoriteViewModel>(favorite);

            return Ok(favoriteViewModel);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.Id == id);
        }
    }
}
