using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Payment;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers.LotManagement.AgreementManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Create(CreatePaymentDTO newPayment)
        {
            try
            {
                await _paymentService.Create(newPayment, GetUserId());
                return Ok("new payment created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetById(Guid paymentId)
        {
            try
            {
                return Ok(await _paymentService.GetById(paymentId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetByAgreementId(Guid agreementId)
        {
            try
            {
                return Ok(await _paymentService.GetByAgreementId(agreementId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetToken()
        {
            try
            {
                return Ok(await _paymentService.GetToken(GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _paymentService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
