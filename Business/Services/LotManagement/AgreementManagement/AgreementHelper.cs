using AutoMapper;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement.AgreementManagement
{
    public static class AgreementHelper
    {
        public static async Task<List<AgreementDTO>> GetPrice(IEnumerable<Agreement> agreements, IMapper _mapper, ILotUnitOfWork _unitOfWork)
        {
            List<AgreementDTO> result = new List<AgreementDTO>();

            foreach (var agreement in agreements)
            {
                AgreementDTO agreementDTO = _mapper.Map<AgreementDTO>(agreement);
                Lot lot = await _unitOfWork.LotRepository.GetById(agreement.LotId);
                if (lot.IsRent)
                {
                    IEnumerable<PriceCoef> priceCoefs = await _unitOfWork.PriceCoefRepository.GetByLotId(lot.Id);

                    if (priceCoefs != null)
                    {
                        foreach (var priceCoef in priceCoefs)
                        {
                            if (priceCoef.IsSelected == true)
                            {
                                agreementDTO.Price = priceCoef.Value;
                            }
                        }
                    }
                }
                else if (lot.IsAuction)
                {
                    agreementDTO.Price = lot.BuyPrice;

                    IEnumerable<Bid> bids = await _unitOfWork.BidRepository.GetByLotId(lot.Id);

                    if (bids != null)
                    {
                        foreach (var bid in bids)
                        {
                            if (bid.IsWinner == true)
                            {
                                agreementDTO.Price = bid.Value;
                            }
                        }
                    }
                }

                result.Add(agreementDTO);
            }

            return result;
        }
    }
}
