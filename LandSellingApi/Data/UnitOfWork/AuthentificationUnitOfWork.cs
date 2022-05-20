using Data.Contract.Repository.Authentication;
using Data.Contract.UnitOfWork;
using Data.EF;
using Data.Repository.Authentication;
using System.Threading.Tasks;

namespace Data.Identity.UnitOfWork
{
    public class AuthentificationUnitOfWork : IAuthentificationUnitOfWork
    {
        private LandSellingContext _landSellingContext;
        private IUserRepository _userRepository;
        private IAdminRepository _adminRepository;

        public AuthentificationUnitOfWork(LandSellingContext domainDbContext)
        {
            _landSellingContext = domainDbContext;
        }
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_landSellingContext);

        public IAdminRepository AdminRepository => _adminRepository ??= new AdminRepository(_landSellingContext);

        public async Task<int> Save() => await _landSellingContext.SaveChangesAsync();
    }
}
