using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Services.LotManagement.AgreementManagement;
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
        public async Task<ActionResult> Create(AgreementDTO newAgreement)
        {
            try
            {
                await _agreementService.Create(newAgreement);
                return Ok("new agreement craeted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
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

        [HttpDelete]
        [Route("[action]")]
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
    }
}
