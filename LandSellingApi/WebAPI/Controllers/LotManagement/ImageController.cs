using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers.LotManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : BaseController
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(ImageDTO newImage)
        {
            try
            {
                await _imageService.Create(newImage);
                return Ok("new image created for the lot " + newImage.LotId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Update(ImageDTO newImage, Guid imageId)
        {
            try
            {
                await _imageService.Update(newImage, imageId);
                return Ok(imageId + " image was updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult> Delete(Guid imageId)
        {
            try
            {
                await _imageService.Delete(imageId);
                return Ok(imageId + " image was deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetAllByLotId(Guid lotId)
        {
            try
            {
                return Ok(await _imageService.GetAllByLotId(lotId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
