using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Agreement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement
{
    public interface IAgreementService
    {
        public Task Create(CreateAgreementDTO createAgreemen);
        public Task Delete(Guid id);
        public Task Update(AgreementDTO updateAgreemen, Guid AgreemenId);
        public Task<AgreementDTO> GetByLotId(Guid lotId);
        public Task<IEnumerable<AgreementDTO>> GetByOwnerId(Guid ownerId);
        public Task<IEnumerable<AgreementDTO>> GetByCustomerId(Guid customerId);
        public Task<IEnumerable<AgreementDTO>> GetByManagerId(Guid managerId);
    }
}
