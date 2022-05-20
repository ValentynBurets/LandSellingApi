using Data.Contract.Repository;
using Data.Contract.Repository.Authentication;
using Data.Contract.Repository.LotManagement;
using Data.Contract.Repository.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork.Base;

namespace Data.Contract.UnitOfWork
{
    public interface ILotUnitOfWork : IUnitOfWorkBase
    {
        ILotRepository LotRepository { get; }
        IBidRepository BidRepository { get; }
        IImageRepository ImageRepository { get; }
        IPriceCoefRepository PriceCoefRepository { get; }
        IUserRepository UserRepository { get;  }
        IAdminRepository ManagerRepository { get; }
        IAgreementRepository AgreementRepository { get; }
        IPaymentRepository PaymentRepository { get; }
    }
}
