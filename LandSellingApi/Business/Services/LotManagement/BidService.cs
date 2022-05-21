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
    public class BidService: IBidService
    {
        private IMapper _mapper;
        private readonly ILotUnitOfWork _unitOfWork;
        public BidService(IMapper mapper, ILotUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(BidDTO createBid, Guid userId)
        {
            Bid newBid = _mapper.Map<Bid>(createBid);
            newBid.BidderId = userId;
            newBid.Date = DateTime.Now;
            await _unitOfWork.BidRepository.Add(newBid);
            await _unitOfWork.Save();
        }

        public async Task<BidDTO> GetById(Guid bidId)
        {
            Bid bid = await _unitOfWork.BidRepository.GetById(bidId);
            return _mapper.Map<BidDTO>(bid);
        }

        public async Task<BidDTO> GetBidWinerByLotId(Guid lotId)
        {
            IEnumerable<Bid> bidsWinners = await _unitOfWork.BidRepository.GetBidsWinners();
            Bid BidWinerByLotId = bidsWinners.Where(b => b.LotId == lotId).First();

            return _mapper.Map<BidDTO>(BidWinerByLotId);
        }

        public async Task<IEnumerable<BidDTO>> GetAllByLotId(Guid bidId)
        {
            IEnumerable<Bid> bids = await _unitOfWork.BidRepository.GetByLotId(bidId);
            return _mapper.Map<IEnumerable<BidDTO>>(bids);
        }

        public async Task<IEnumerable<BidDTO>> GetAllByBidderId(Guid bidderId)
        {
            IEnumerable<Bid> bids = await _unitOfWork.BidRepository.GetByBidderId(bidderId);
            return _mapper.Map<IEnumerable<BidDTO>>(bids);
        }

        public async Task<IEnumerable<BidDTO>> GetAllBidWinnersByBidderId(Guid bidderId)
        {
            IEnumerable<Bid> bidsWinners = await _unitOfWork.BidRepository.GetBidsWinners();
            IEnumerable<Bid> BidWinerByBidderId = bidsWinners.Where(b => b.BidderId == bidderId).ToList();

            return _mapper.Map<IEnumerable<BidDTO>>(BidWinerByBidderId);
        }
    }
}
