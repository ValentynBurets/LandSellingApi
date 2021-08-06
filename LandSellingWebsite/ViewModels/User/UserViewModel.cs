using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        //public string Name { get; set; }
        //public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
