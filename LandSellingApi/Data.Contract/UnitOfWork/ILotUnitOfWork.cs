using Data.Contract.Repository;
using Data.Contract.Repository.Authentication;
using Data.Contract.Repository.LotManagement;
using Data.Contract.UnitOfWork.Base;

namespace Data.Contract.UnitOfWork
{
    public interface ILotUnitOfWork : IUnitOfWorkBase
    {
        ILotRepository LotRepository { get; }
        IRealEstateRepository RealEstateRepository { get; }
        IRentRepository RentRepository { get; }
        ISellingRepository SellingRepository { get; }
        IBidRepository BidRepository { get; }
        IFavoriteRepository FavoriteRepository {  get; }
        IImageRepository ImageRepository { get; }
        IPriceCoefRepository PriceCoefRepository { get; }
        ICustomerRepository CustomerRepository { get;  }
        IManagerRepository ManagerRepository { get; }
    }
}
