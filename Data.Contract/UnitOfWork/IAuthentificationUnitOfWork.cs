using Data.Contract.Repository;
using Data.Contract.Repository.Authentication;
using Data.Contract.UnitOfWork.Base;

namespace Data.Contract.UnitOfWork
{
    public interface IAuthentificationUnitOfWork : IUnitOfWorkBase
    {
        IUserRepository UserRepository { get; }
        IAdminRepository AdminRepository { get; }
    }
}