using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Domain.Entity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : BaseController
    {
        private readonly ILotService _lotService;

        public LotController(ILotService lotService)
        {
            _lotService = lotService;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Create(CreateLotDTO newLot)
        {
            try
            {
                return Ok(await _lotService.Create(newLot, GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Take(Guid lotId)
        {
            try
            {
                var IdLink = GetUserId();
                await _lotService.Take(lotId, IdLink);
                return Ok("lot taken by manager idLink: " + IdLink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Update(UpdateLotDTO newLot, Guid lotId)
        {
            try
            {
                await _lotService.Update(newLot, lotId);
                return Ok(lotId + " lot updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> Viewed(Guid lotId)
        {
            try
            {
                await _lotService.Viewed(lotId);
                return Ok(lotId + "lot updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Approve(Guid lotId)
        {
            try
            {
                await _lotService.Approve(lotId);
                return Ok(lotId + " lot approved");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Delete(Guid lotId)
        {
            try
            {
                await _lotService.Delete(lotId);
                return Ok(lotId + " lot deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetById(Guid lotId)
        {
            try
            {
                return Ok(await _lotService.GetById(lotId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetMy(Guid lotId)
        {
            try
            {
                return Ok(await _lotService.GetMy(GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _lotService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(GetLotOptionsDTO getLotOptionsDTO)
        {
            try
            {
                return Ok(await _lotService.Get(getLotOptionsDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetViewsByLotId(Guid lotId)
        {
            try
            {
                return Ok(await _lotService.GetViewsByLotId(lotId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public ActionResult GetQuantity()
        {
            try
            {
                return Ok(_lotService.GetQuantity());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAverageViewsPerLot()
        {
            try
            {
                return Ok(await _lotService.GetAverageViewsPerLot());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
