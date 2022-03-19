using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : BaseController
    {
        private readonly ILotService _lotService;

        public LotController(ILotService attemptService)
        {
            _lotService = attemptService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(CreateLotDTO newLot)
        {
            try
            {
                await _lotService.Create(newLot, GetUserId());
                return Ok("new lot craeted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
