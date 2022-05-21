using Business.Contract.Model.LotManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface IPriceCoefService
    {
        public Task Create(PriceCoefDTO createPriceCoef);
        public Task Delete(Guid id);
        public Task Update(PriceCoefDTO updatePriceCoef, Guid priceCoefId);
        public Task<IEnumerable<PriceCoefDTO>> GetAllByLotId(Guid lotId);
    }
}
