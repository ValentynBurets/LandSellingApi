using Business.Contract.Model.LotManagement.AgreementManagement;
using System;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement
{
    public interface IAgreementService
    {
        public Task Create(AgreementDTO createAgreemen);
        public Task Delete(Guid id);
        public Task Update(AgreementDTO updateAgreemen, Guid AgreemenId);
    }
}
