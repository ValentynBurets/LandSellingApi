using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Agreement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement
{
    public interface IAgreementService
    {
        public Task<Guid> Create(CreateAgreementDTO createAgreemen, Guid customerIdLink);
        public Task Delete(Guid id);
        public Task Update(AgreementDTO updateAgreemen, Guid AgreemenId);
        public Task<AgreementDTO> GetByLotId(Guid lotId);
        public Task<IEnumerable<AgreementDTO>> GetByOwnerId(Guid ownerIdLink);
        public Task<IEnumerable<AgreementDTO>> GetMy(Guid ownerId);
        public Task<IEnumerable<AgreementDTO>> GetByCustomerId(Guid customerId);
        public Task<IEnumerable<AgreementDTO>> GetByManagerId(Guid managerId);
        public Task Take(Guid lotId, Guid managerId);
        public Task Approve(Guid agreementId);
        public Task Disapprove(Guid agreementId);
    }
}
