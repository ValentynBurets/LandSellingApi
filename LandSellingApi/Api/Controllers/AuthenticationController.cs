﻿using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Services.Authentication;
using Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly UserManager<AuthorisationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IProfileRegistrationService _profileRegistrationService;

        public AuthenticationController(
            UserManager<AuthorisationUser> userManager,
            IMapper mapper,
            IAuthManager authManager,
            IProfileRegistrationService profileRegistrationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
            _profileRegistrationService = profileRegistrationService;
        }

        [NonAction]
        private async Task<IActionResult> RegisterUser(RegisterUserModel userModel, string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<AuthorisationUser>(userModel);
                user.UserName = userModel.Email;

                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddToRoleAsync(user, role);

                await _profileRegistrationService.CreateProfile(user, userModel.FirstName, userModel.LastName);

                if (!await _authManager.ValidateUser(userModel))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterUserModel userModel)
        {
            return await RegisterUser(userModel, "Customer");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserModel userModel)
        {
            return await RegisterUser(userModel, "Admin");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userModel))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
