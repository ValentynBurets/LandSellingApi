using Business.Contract.Model.LotManagement.Lot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface ILotService  
    {
        public Task Create(CreateLotDTO createLot);
        public Task Delete(Guid id);
        public Task Update(UpdateLotDTO updateLot, Guid lotId);
    }
}
