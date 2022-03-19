using Business.Contract.Services.Authentication;
using Data.Contract.UnitOfWork;
using Data.Identity;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Authentication
{
    public class ProfileRegistrationService : IProfileRegistrationService
    {
        private readonly UserManager<AuthorisationUser> _userManager;
        private IAuthentificationUnitOfWork _unitOfWork;
        public ProfileRegistrationService(UserManager<AuthorisationUser> userManager,
            IAuthentificationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<bool> CreateProfile(AuthorisationUser user, string firstName, string lastName)
        {
            IList<string> role = await _userManager.GetRolesAsync(user);
            if (role.Contains("Customer"))
            {
                await _unitOfWork.CustomerRepository.Add(new Customer(Guid.Parse(user.Id))
                {
                    Name = firstName,
                    SurName = lastName
                });
                await _unitOfWork.Save();
                return true;
            }
            else if (role.Contains("Admin"))
            {
                await _unitOfWork.AdminRepository.Add(new Admin(Guid.Parse(user.Id))
                {
                    Name = firstName,
                    SurName = lastName
                });
                await _unitOfWork.Save();
                return true;
            }
            else
            {
                throw new Exception("Role is not set");
            }
        }
    }
}
