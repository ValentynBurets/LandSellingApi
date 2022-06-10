using Business.Contract.Model.LotManagement;
using Business.Contract.Model.LotManagement.Bid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement
{
    public interface IBidService
    {
        Task Create(CreateBidDTO createBid, Guid userId);
        Task<BidDTO> GetById(Guid bidId);
        Task<BidDTO> GetBidWinerByLotId(Guid bidId);
        Task<IEnumerable<BidDTO>> GetAllByLotId(Guid bidId);
        Task<IEnumerable<BidDTO>> GetAllByBidderId(Guid userId);
        Task<IEnumerable<BidDTO>> GetAllBidWinnersByBidderId(Guid userId);
        int GetQuantity();

    }
}