using Business.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Services.Authentication
{
    public interface IProfileManager
    {
        public Task<string> GetEmailByUserId(Guid id);
        public Task<string> GetPhoneNumberByUserId(Guid id);
        public Task UpdateEmailByUserId(UpdateEmailModel model, Guid id);
        public Task UpdatePasswordByUserId(UpdatePasswordModel model, Guid id);
    }
}

