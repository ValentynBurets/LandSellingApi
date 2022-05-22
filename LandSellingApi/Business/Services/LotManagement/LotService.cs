using AutoMapper;
using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.Lot;
using Business.Contract.Services.LotManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.LotManagement
{
    public class LotService : ILotService
    {
        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        public LotService(IMapper mapper, ILotUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(LotDTO createLot, Guid ownerId)
        {
            Lot newLot = _mapper.Map<Lot>(createLot);
            newLot.OwnerId = ownerId;
            newLot.PublicationDate = DateTime.Now;
                
            Location location = new Location()
            {
                Latitude = createLot.Location.Latitude,
                Longitude = createLot.Location.Longitude,
                Country = createLot.Location.Country,
                Region = createLot.Location.Region,
                City = createLot.Location.City,
                Street = createLot.Location.Street
            };
            await _unitOfWork.LocationRepository.Add(location);
            await _unitOfWork.Save();

            newLot.LocationId = await _unitOfWork.LocationRepository.GetByLongitudeAndLatitude(createLot.Location.Longitude, createLot.Location.Latitude);

            await _unitOfWork.LotRepository.Add(newLot);
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            var lot = await _unitOfWork.LotRepository.GetById(id);
            await _unitOfWork.LotRepository.Remove(lot);
            await _unitOfWork.Save();
        }

        public async Task Update(LotDTO updateLot, Guid lotId)
        {
            Lot newLot = _mapper.Map<Lot>(updateLot);
            await _unitOfWork.LotRepository.Update(newLot);
            await _unitOfWork.Save();
        }

        public async Task<ReturnLotDTO> GetById(Guid lotId)
        {
            Lot lot = await _unitOfWork.LotRepository.GetById(lotId);
            Location location = await _unitOfWork.LocationRepository.GetById(lot.LocationId);
            LocationDTO locationDTO = _mapper.Map<LocationDTO>(location);
            ReturnLotDTO lotDTO = _mapper.Map<ReturnLotDTO>(lot);
            lotDTO.Location = locationDTO;
            return lotDTO;
        }

        public async Task<IEnumerable<ReturnLotDTO>> GetAll()
        {
            IEnumerable<Lot> lots = await _unitOfWork.LotRepository.GetAll();
            List<ReturnLotDTO> lotDTOs = new List<ReturnLotDTO>();

            foreach (Lot lot in lots)
            {
                ReturnLotDTO lotDTO = _mapper.Map<ReturnLotDTO>(lot);
                Location location = await _unitOfWork.LocationRepository.GetById(lot.LocationId);
                LocationDTO locationDTO = _mapper.Map<LocationDTO>(location);
                lotDTO.Location = locationDTO;
                lotDTOs.Add(lotDTO);
            }
            return lotDTOs;
        }
    }
}
