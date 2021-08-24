using LandSellingWebsite.Data.Repositories;
using LandSellingWebsite.Data.Services.Abstract;
using LandSellingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.Data.Services
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(LandSellingDBContext context) : base(context) { }

        public bool IsEmailUniq(string email)
        {
            return !this.Exist(u => u.Email == email);
        }

        public bool IsPhoneUniq(string phoneNumber)
        {
            return !this.Exist(u => u.PhoneNumber == phoneNumber);
        }
    }
}
