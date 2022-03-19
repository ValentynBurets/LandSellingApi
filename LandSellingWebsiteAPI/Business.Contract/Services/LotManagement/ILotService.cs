using Business.Contract.Model.LotManagement;
using System;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface ILotService  
    {
        public Task Create(CreateLotDTO createLot, Guid id);
        public Task Delete(Guid id);
        public Task Update(UpdateLotDTO updateLot, Guid lotId);
    }
}
