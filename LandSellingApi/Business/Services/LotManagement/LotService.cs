using AutoMapper;
using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.Lot;
using Business.Contract.Services.LotManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using Domain.Entity.Constants;
using Domain.Entity.LotManagement;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Guid> Create(CreateLotDTO createLot, Guid ownerIdLink)
        {
            Lot newLot = _mapper.Map<Lot>(createLot);
            newLot.Status = Domain.Entity.Constants.State.Open;
            newLot.OwnerId = (await _unitOfWork.UserRepository.GetByIdLink(ownerIdLink)).Id;
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

            newLot.LocationId = await _unitOfWork.LocationRepository.Add(location);

            await _unitOfWork.LotRepository.Add(newLot);
            Guid lotId = await _unitOfWork.LotRepository.GetByLocationId(newLot.LocationId);
            return lotId;
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
            newLot.Id = lotId;
            await _unitOfWork.LotRepository.Update(newLot);
            await _unitOfWork.Save();
        }

        public async Task Viewed(Guid lotId)
        {
            Lot lot = await _unitOfWork.LotRepository.GetById(lotId);
            
            lot.Views++;
            
            await _unitOfWork.LotRepository.Update(lot);
            await _unitOfWork.Save();
        }

        public async Task Approve(Guid lotId)
        {
            LotManager lotManager = await _unitOfWork.LotManagerRepository.GetByLotId(lotId);
            lotManager.Approved = true;
            await _unitOfWork.LotManagerRepository.Update(lotManager);
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
        public async Task<IEnumerable<ReturnLotDTO>> GetMy(Guid ownerIdLink)
        {
            var ownerId = (await _unitOfWork.UserRepository.GetByIdLink(ownerIdLink)).Id;
            IEnumerable<Lot> lots = await _unitOfWork.LotRepository.GetByOwnerId(ownerId);
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

        public async Task<IEnumerable<ReturnSimpleLotDTO>> Get(GetLotOptionsDTO getLotOptionsDTO)
        {
            GetLotOptions getLotOptions = _mapper.Map<GetLotOptions>(getLotOptionsDTO);

            IEnumerable<Lot> lots = await _unitOfWork.LotRepository.GetByLotType(getLotOptions.LotType);
            
            if (getLotOptions.State == State.Open)
            {
                lots = lots.Where(l => l.Status == State.Open).ToArray();
            }
            else if (getLotOptions.State == State.Close)
            {
                lots = lots.Where(l => l.Status == State.Close).ToArray();
            }

            if(getLotOptions.SortType == SortType.ByCostRaising)
            {
                lots = lots.OrderBy(l => l.BuyPrice);
            }
            else if (getLotOptions.SortType == SortType.ByСostDescending)
            {
                lots = lots.OrderByDescending(l => l.BuyPrice);
            }

            List<ReturnSimpleLotDTO> lotDTOs = new List<ReturnSimpleLotDTO>();

            foreach (Lot lot in lots)
            {
                ReturnSimpleLotDTO lotDTO = _mapper.Map<ReturnSimpleLotDTO>(lot);
                Location location = await _unitOfWork.LocationRepository.GetById(lot.LocationId);
                LocationDTO locationDTO = _mapper.Map<LocationDTO>(location);
                if (locationDTO.Country == null)
                    locationDTO.Country = "";
                if (locationDTO.City == null)
                    locationDTO.City = "";
                if (locationDTO.House == null)
                    locationDTO.House = "";
                if (locationDTO.Street == null)
                    locationDTO.Street = "";
                if (locationDTO.Region == null)
                    locationDTO.Region = "";

                lotDTO.Location = locationDTO;
                lotDTOs.Add(lotDTO);
            }
            return lotDTOs;
        }

        public async Task<int> GetViewsByLotId(Guid lotId)
        {
            return await _unitOfWork.LotRepository.GetViewsByLotId(lotId);
        }

        //add manager Id to lot
        //should approve manager
        public async Task Take(Guid lotId, Guid managerIdLink)
        {
            var lotManager = new LotManager();
            lotManager.LotId = lotId;
            lotManager.ManagerId = (await _unitOfWork.UserRepository.GetByIdLink(managerIdLink)).Id;

            await _unitOfWork.LotManagerRepository.Add(lotManager);
            await _unitOfWork.Save();
        }
    }
}
