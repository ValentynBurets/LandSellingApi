using Business.Contract.Model.LotManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface ILotService  
    {
        Task<Guid> Create(CreateLotDTO createLot, Guid ownerId);
        Task Delete(Guid id);
        Task Update(UpdateLotDTO updateLot, Guid lotId);
        Task Viewed(Guid lotId);
        Task Approve(Guid lotId);
        Task<ReturnLotDTO> GetById(Guid lotId);
        Task<IEnumerable<ReturnLotDTO>> GetAll();
        Task<IEnumerable<ReturnSimpleLotDTO>> Get(GetLotOptionsDTO getLotOptionsDTO);
        Task<IEnumerable<ReturnLotDTO>> GetMy(Guid ownerIdLink);
        Task<int> GetViewsByLotId(Guid lotId);
        Task Take(Guid lotId, Guid managerId);
        int GetQuantity();
        Task<int> GetAverageViewsPerLot();
    }
}
