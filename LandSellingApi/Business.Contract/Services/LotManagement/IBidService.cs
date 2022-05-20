using Business.Contract.Model.LotManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface IBidService
    {
        public Task Create(BidDTO createBid, Guid lotId, Guid userId);
        public Task<BidDTO> GetById(Guid bidId);
        public Task<BidDTO> GetBidWinerByLotId(Guid bidId);
        public Task<IEnumerable<BidDTO>> GetAllByLotId(Guid bidId);
        public Task<IEnumerable<BidDTO>> GetAllByBidderId(Guid userId);
        public Task<IEnumerable<BidDTO>> GetAllBidWinnersByBidderId(Guid userId);

    }
}