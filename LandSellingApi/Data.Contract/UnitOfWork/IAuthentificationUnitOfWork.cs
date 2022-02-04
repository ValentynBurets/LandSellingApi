using Data.Contract.Repository;
using Data.Contract.Repository.Authentication;
using Data.Contract.UnitOfWork.Base;

namespace Data.Contract.UnitOfWork
{
    public interface IAuthentificationUnitOfWork : IUnitOfWorkBase
    {
        ICustomerRepository CustomerRepository { get; }
        IAdminRepository AdminRepository { get; }
    }
}