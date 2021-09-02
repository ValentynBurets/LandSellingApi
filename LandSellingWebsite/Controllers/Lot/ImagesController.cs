using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using AutoMapper;
using LandSellingWebsite.ViewModels.Lot;
using LandSellingWebsite.ViewModels.Lot.Image;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public ImagesController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageViewModel>>> GetImages()
        {
            var images = await _context.Images.ToListAsync();
            var imagesViewModel = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageViewModel>>(images);

            return Ok(imagesViewModel); 
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageViewModel>> GetImage(int id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            var imageViewModel = _mapper.Map<Image, ImageViewModel>(image);

            return Ok(imageViewModel);
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(int id, PostImageViewModel postImageViewModel)
        {
            var image = _mapper.Map<PostImageViewModel, Image>(postImageViewModel);

            image.Id = id;

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageViewModel>> PostImage(PostImageViewModel postImageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //postImageViewModel
            var image = _mapper.Map<PostImageViewModel, Image>(postImageViewModel);
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            var imageViewModel = _mapper.Map<Image, ImageViewModel>(image);

            return Ok(imageViewModel);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
