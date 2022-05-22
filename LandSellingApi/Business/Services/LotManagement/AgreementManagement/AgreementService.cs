using AutoMapper;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Agreement;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
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
        public async Task Create(CreateAgreementDTO createAgreement)
        {
            Agreement newAgreement = _mapper.Map<Agreement>(createAgreement);
            newAgreement.CreationDate = DateTime.Now;
            await _unitOfWork.AgreementRepository.Add(newAgreement);
            await _unitOfWork.Save();
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

        public async Task<AgreementDTO> GetByLotId(Guid lotId)
        {
            Agreement agreement = await _unitOfWork.AgreementRepository.GetByLotId(lotId); 
            return _mapper.Map<AgreementDTO>(agreement);
        }

        public async Task<IEnumerable<AgreementDTO>> GetByOwnerId(Guid ownerId)
        {
            IEnumerable<Agreement> agreement = await _unitOfWork.AgreementRepository.GetByOwnerId(ownerId);
            return _mapper.Map< IEnumerable<AgreementDTO>>(agreement);
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
    }
}
