using Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Services.Authentication
{
    public interface IProfileRegistrationService
    {
        public Task<bool> CreateProfile(AuthorisationUser user, string firstName, string lastName);
    }
}
