using AutoMapper;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
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
        public async Task Create(AgreementDTO createAgreement)
        {
            Agreement newAgreement = _mapper.Map<Agreement>(createAgreement);
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
    }
}
