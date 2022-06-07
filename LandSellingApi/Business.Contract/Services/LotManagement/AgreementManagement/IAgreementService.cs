using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Agreement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement
{
    public interface IAgreementService
    {
        Task<Guid> Create(CreateAgreementDTO createAgreemen, Guid customerIdLink);
        Task Delete(Guid id);
        Task Update(AgreementDTO updateAgreemen, Guid AgreemenId);
        Task<IEnumerable<AgreementDTO>> GetByLotId(Guid lotId);
        Task<IEnumerable<AgreementDTO>> GetByOwnerId(Guid ownerIdLink);
        Task<IEnumerable<AgreementDTO>> GetMy(Guid ownerId);
        Task<IEnumerable<AgreementDTO>> GetMyAsCustomer(Guid CustomerId);
        Task<IEnumerable<AgreementDTO>> GetByCustomerId(Guid customerId);
        Task<IEnumerable<AgreementDTO>> GetByManagerId(Guid managerId);
        Task Take(Guid lotId, Guid managerId);
        Task Approve(Guid agreementId);
        Task Disapprove(Guid agreementId);
        int GetQuantity();
    }
}
