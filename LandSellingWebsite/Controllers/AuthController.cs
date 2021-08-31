using LandSellingWebsite.Data.Services.Abstract;
using LandSellingWebsite.Models;
using LandSellingWebsite.Options;
using LandSellingWebsite.ViewModels;
using LandSellingWebsite.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly LandSellingDBContext _context;

        public AuthController(LandSellingDBContext context, IAuthService authService, IUserRepository userRepository)
        {
            this._authService = authService;
            _userRepository = userRepository;
            _context = context;
        }

        [HttpPost("login")]
        public ActionResult<AuthData> Post([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _context.AppUsers.Include(x => x.Role)
                .FirstOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);

            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            var authData = _authService.GetAuthData(user.Id.ToString());
            authData.Name = user.Name;
            authData.Surname = user.SurName;
            authData.RoleId = user.RoleId;
            authData.RoleName = user.Role.Name;
            authData.Email = user.Email;

            return authData;
        }
    

        [HttpPost("register")]
        public ActionResult<AuthData> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = _userRepository.IsEmailUniq(model.Email);
            var phoneUniq = _userRepository.IsPhoneUniq(model.PhoneNumber);


            if (!emailUniq) return BadRequest(new { email = "user with this email already exists" });


            var id = Guid.NewGuid().ToString();
            var user = new AppUser
            {
                Id = Int32.Parse(id),
                Name = model.Name,
                SurName = model.SurName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = _authService.HashPassword(model.Password),
                RoleId = 2
            };
            _userRepository.Add(user);


            return _authService.GetAuthData(id);
        } 
    }
}
