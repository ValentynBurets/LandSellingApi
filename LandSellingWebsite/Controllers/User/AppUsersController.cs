using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandSellingWebsite.Models;
using AutoMapper;
using LandSellingWebsite.ViewModels.User;
using System.Reflection;

namespace LandSellingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly LandSellingDBContext _context;
        private readonly IMapper _mapper;

        public AppUsersController(LandSellingDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAppUsers()
        {

            var users = await _context.AppUsers.Include(Item => Item.Role).ToListAsync();
            //var users = await _context.AppUsers.ToListAsync();
            var usersViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userViewModel = _mapper.Map<AppUser, UserViewModel>(user);
                userViewModel.RoleName = user.Role.Name;
                usersViewModels.Add(userViewModel);
            }

            return Ok(usersViewModels);
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetAppUser(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var appUserViewModel = _mapper.Map<AppUser, UserViewModel>(appUser);

            return appUserViewModel;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, PostUserViewModel appUser)
        {

            AppUser user = _mapper.Map<PostUserViewModel, AppUser>(appUser);
            user.Id = id;
            
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostUserViewModel>> PostAppUser(PostUserViewModel appUser)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXECUTE AddPerson {appUser.Name}, {appUser.SurName}, {appUser.PhoneNumber}, {appUser.Email}, {appUser.Password},  {appUser.RoleId}");

            return appUser;
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppUserExists(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
