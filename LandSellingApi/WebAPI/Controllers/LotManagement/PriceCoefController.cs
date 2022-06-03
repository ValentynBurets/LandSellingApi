using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers.LotManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceCoefController : BaseController
    {
        private readonly IPriceCoefService _priceCoefService;
        public PriceCoefController(IPriceCoefService priceCoefService)
        {
            _priceCoefService = priceCoefService;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Create(PriceCoefDTO newPriceCoef)
        {
            try
            {
                await _priceCoefService.Create(newPriceCoef);
                return Ok("new priceCoef craeted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Update(PriceCoefDTO newPriceCoef, Guid priceCoefId)
        {
            try
            {
                await _priceCoefService.Update(newPriceCoef, priceCoefId);
                return Ok(priceCoefId + " priceCoef updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Select(Guid priceCoefId)
        {
            try
            {
                await _priceCoefService.Select(priceCoefId);
                return Ok(priceCoefId + " priceCoef selected");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Delete(Guid priceCoefId)
        {
            try
            {
                await _priceCoefService.Delete(priceCoefId);
                return Ok(priceCoefId + " priceCoef deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllByLotId(Guid lotId)
        {
            try
            {
                return Ok(await _priceCoefService.GetAllByLotId(lotId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
