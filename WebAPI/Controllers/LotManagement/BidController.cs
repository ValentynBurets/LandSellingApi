﻿using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers.LotManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : BaseController
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Create(CreateBidDTO createBid)
        {
            try
            {
                await _bidService.Create(createBid, GetUserId());
                return Ok("new bid created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetById(Guid bidId)
        {
            try
            {
                return Ok(await _bidService.GetById(bidId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetBidWinerByLotId(Guid lotId)
        {
            try
            {
                return Ok(await _bidService.GetBidWinerByLotId(lotId));
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
                return Ok(await _bidService.GetAllByLotId(lotId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetAllByBidderId(Guid bidderId)
        {
            try
            {
                return Ok(await _bidService.GetAllByBidderId(bidderId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> GetAllBidWinnersByBidderId(Guid bidderId)
        {
            try
            {
                return Ok(await _bidService.GetAllBidWinnersByBidderId(bidderId));
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
                return Ok(_bidService.GetQuantity());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
