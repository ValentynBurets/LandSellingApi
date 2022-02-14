using AutoMapper;
using Business.Contract.Model.LotManagement;
using Business.Contract.Services.LotManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.LotManagement
{
    internal class LotService : ILotService
    {
        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        public LotService(IMapper mapper, ILotUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(CreateLotDTO createLot)
        {

            Lot newLot = _mapper.Map<Lot>(createLot);
            await _unitOfWork.LotRepository.Add(newLot);
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            var lot = await _unitOfWork.LotRepository.GetById(id);
            await _unitOfWork.LotRepository.Remove(lot);
            await _unitOfWork.Save();
        }

        public async Task Update(UpdateLotDTO updateLot, Guid lotId)
        {
            Lot newLot = _mapper.Map<Lot>(updateLot);
            await _unitOfWork.LotRepository.Update(newLot);
            await _unitOfWork.Save();
        }
    }
}
