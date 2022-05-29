using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.Lot;
using Domain.Entity.Constants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface ILotService  
    {
        public Task<Guid> Create(CreateLotDTO createLot, Guid ownerId);
        public Task Delete(Guid id);
        public Task Update(UpdateLotDTO updateLot, Guid lotId);
        public Task Viewed(Guid lotId);
        public Task Approve(Guid lotId);
        public Task<ReturnLotDTO> GetById(Guid lotId);
        public Task<IEnumerable<ReturnLotDTO>> GetAll();
        public Task<IEnumerable<ReturnSimpleLotDTO>> Get(GetLotOptionsDTO getLotOptionsDTO);
        public Task<IEnumerable<ReturnLotDTO>> GetMy(Guid ownerIdLink);
        public Task<int> GetViewsByLotId(Guid lotId);
        public Task Take(Guid lotId, Guid managerId);
    }
}
