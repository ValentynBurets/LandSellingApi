using LandSellingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.Data.Services.Abstract
{
    public interface IUserRepository : IRepository<AppUser>
    {
        bool IsEmailUniq(string email);

        bool IsPhoneUniq(string phoneNumber);
    }
}
