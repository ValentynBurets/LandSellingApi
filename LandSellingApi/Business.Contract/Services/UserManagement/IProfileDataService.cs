using Business.Contract.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.Authentication
{
    public interface IProfileDataService
    {
        public Task<UserInfoViewModel> GetCustomerProfileInfoById(Guid id);
        public Task<IEnumerable<UserInfoViewModel>> GetAllUsersInfo();
        public Task<UserInfoViewModel> GetAdminProfileInfoById(Guid id);
        public Task UpdateCustomerProfileInfoById(ProfileInfoModel model, Guid id);
        public Task UpdateAdminProfileInfoById(ProfileInfoModel model, Guid id);
    }
}