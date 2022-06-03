using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Agreement;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers.LotManagement.AgreementManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : BaseController
    {
        private readonly IAgreementService _agreementService;

        public AgreementController(IAgreementService agreementService)
        {
            _agreementService = agreementService;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Create(CreateAgreementDTO newAgreement)
        {
            try
            {
                var id = await _agreementService.Create(newAgreement, GetUserId());
                return Ok($"new agreement with id {id} craeted");
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
                await _agreementService.Take(lotId, GetUserId());
                return Ok("new agreement craeted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Update(AgreementDTO newAgreement, Guid agreementId)
        {
            try
            {
                await _agreementService.Update(newAgreement, agreementId);
                return Ok(agreementId + " agreement updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Approve(Guid agreementId)
        {
            try
            {
                await _agreementService.Approve(agreementId);
                return Ok(agreementId + " agreement updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Disapprove(Guid agreementId)
        {
            try
            {
                await _agreementService.Disapprove(agreementId);
                return Ok(agreementId + " agreement updated");
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
                await _agreementService.Delete(lotId);
                return Ok(lotId + " agreement deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetByLotId(Guid lotId)
        {
            try
            {
                var result =  await _agreementService.GetByLotId(lotId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetByOwnerId(Guid ownerId)
        {
            try
            {
                var result = await _agreementService.GetByOwnerId(ownerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetMy()
        {
            try
            {
                var result = await _agreementService.GetMy(GetUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetByCustomerId(Guid customerId)
        {
            try
            {
                var result = await _agreementService.GetByCustomerId(customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetByManagerId(Guid managerId)
        {
            try
            {
                var result = await _agreementService.GetByManagerId(managerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
