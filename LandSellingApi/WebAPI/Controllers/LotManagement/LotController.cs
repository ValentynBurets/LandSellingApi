﻿using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.Lot;
using Business.Contract.Services.LotManagement;
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
        public async Task<ActionResult> Create(CreateLotDTO newLot)
        {
            try
            {
                await _lotService.Create(newLot, GetUserId());
                return Ok("new lot craeted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
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

        [HttpDelete]
        [Route("[action]")]
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
    }
}
