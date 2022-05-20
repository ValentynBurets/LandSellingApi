using AutoMapper;
using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.LotManagement
{
    public class PriceCoefService : IPriceCoefService
    {

        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        public PriceCoefService(IMapper mapper, ILotUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(PriceCoefDTO createPriceCoef)
        {
            var newPriceCoef = _mapper.Map<PriceCoef>(createPriceCoef);
            await _unitOfWork.PriceCoefRepository.Add(newPriceCoef);
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid priceCoefId)
        {
            var priceCoef = await _unitOfWork.PriceCoefRepository.GetById(priceCoefId);
            await _unitOfWork.PriceCoefRepository.Remove(priceCoef);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<PriceCoefDTO>> GetAllByLotId(Guid lotId)
        {
            var priceCoefs = await _unitOfWork.PriceCoefRepository.GetByLotId(lotId);
            return _mapper.Map<IEnumerable<PriceCoefDTO>>(priceCoefs);
        }

        public async Task Update(PriceCoefDTO updatePriceCoef, Guid priceCoefId)
        {
            PriceCoef newPriceCoef = _mapper.Map<PriceCoef>(updatePriceCoef);
            await _unitOfWork.PriceCoefRepository.Update(newPriceCoef);
            await _unitOfWork.Save();
        }
    }
}
