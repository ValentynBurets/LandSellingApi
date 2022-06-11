using AutoMapper;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using Domain.Entity.Constants;
using Domain.Entity.LotManagement.AgreementManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.LotManagement.AgreementManagement
{
    public class AgreementService : IAgreementService
    {
        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        public AgreementService(IMapper mapper, ILotUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Create(CreateAgreementDTO createAgreement, Guid customerIdLink)
        {
            Agreement newAgreement = _mapper.Map<Agreement>(createAgreement);
            newAgreement.Status = State.Default;
            newAgreement.CustomerId = (await _unitOfWork.UserRepository.GetByIdLink(customerIdLink)).Id;
            newAgreement.CreationDate = DateTime.Now;
            return await _unitOfWork.AgreementRepository.Add(newAgreement);
        }

        public async Task Delete(Guid id)
        {
            Agreement agreement = await _unitOfWork.AgreementRepository.GetById(id);
            await _unitOfWork.AgreementRepository.Remove(agreement);
            await _unitOfWork.Save();
        }

        public async Task Update(AgreementDTO updateAgreement, Guid AgreemenId)
        {
            Agreement newAgreement = _mapper.Map<Agreement>(updateAgreement);
            await _unitOfWork.AgreementRepository.Update(newAgreement);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<AgreementDTO>> GetByLotId(Guid lotId)
        {
            IEnumerable<Agreement> agreements = await _unitOfWork.AgreementRepository.GetByLotId(lotId); 
            return _mapper.Map<IEnumerable<AgreementDTO>>(agreements);
        }

        public async Task<IEnumerable<AgreementDTO>> GetByOwnerId(Guid ownerId)
        {
            IEnumerable<Agreement> agreement = await _unitOfWork.AgreementRepository.GetByOwnerId(ownerId);
            return _mapper.Map< IEnumerable<AgreementDTO>>(agreement);
        }
        public async Task<IEnumerable<AgreementDTO>> GetMy(Guid ownerIdLink)
        {
            var ownerId = (await _unitOfWork.UserRepository.GetByIdLink(ownerIdLink)).Id;
            IEnumerable<Agreement> agreements = await _unitOfWork.AgreementRepository.GetByOwnerId(ownerId);

            return await AgreementHelper.GetPrice(agreements, _mapper, _unitOfWork);
        }

        public async Task<IEnumerable<AgreementDTO>> GetMyAsCustomer(Guid customerIdLink)
        {
            var ownerId = (await _unitOfWork.UserRepository.GetByIdLink(customerIdLink)).Id;
            IEnumerable<Agreement> agreements = await _unitOfWork.AgreementRepository.GetByCustomerId(ownerId);


            return await AgreementHelper.GetPrice(agreements, _mapper, _unitOfWork);
        }

        public async Task<IEnumerable<AgreementDTO>> GetByCustomerId(Guid customerId)
        {
            IEnumerable<Agreement> agreement = await _unitOfWork.AgreementRepository.GetByCustomerId(customerId);
            return _mapper.Map<IEnumerable<AgreementDTO>>(agreement);
        }

        public async Task<IEnumerable<AgreementDTO>> GetByManagerId(Guid managerId)
        {
            IEnumerable<Agreement> agreement = await _unitOfWork.AgreementRepository.GetByManagerId(managerId);
            return _mapper.Map<IEnumerable<AgreementDTO>>(agreement);
        }

        public async Task Take(Guid agreementId, Guid managerIdLink)
        {
            var agreementManager = new AgreementManager();
            agreementManager.AgreementId = agreementId;
            agreementManager.ManagerId = (await _unitOfWork.UserRepository.GetByIdLink(managerIdLink)).Id;

            await _unitOfWork.AgreementManagerRepository.Add(agreementManager);
            await _unitOfWork.Save();
        }

        public async Task Approve(Guid agreementId)
        {
            Agreement agreement = await _unitOfWork.AgreementRepository.GetById(agreementId);
            agreement.Approved = true;
            agreement.Status = State.Open;
            await _unitOfWork.AgreementRepository.Update(agreement);
            await _unitOfWork.Save();
        }

        public async Task Disapprove(Guid agreementId)
        {
            Agreement agreement = await _unitOfWork.AgreementRepository.GetById(agreementId);
            agreement.Approved = false;
            agreement.Status = State.Close;
            await _unitOfWork.AgreementRepository.Update(agreement);
            await _unitOfWork.Save();
        }

        public int GetQuantity()
        {
            return _unitOfWork.LotRepository.GetQuantity();
        }
    }
}
