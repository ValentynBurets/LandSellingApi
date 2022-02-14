using Data.Contract.Repository;
using Data.Contract.Repository.Authentication;
using Data.Contract.Repository.LotManagement;
using Data.Contract.UnitOfWork;
using Data.EF;
using Data.Repository;
using Data.Repository.Authentication;
using Data.Repository.LotManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class LotUnitOfWork : ILotUnitOfWork
    {
        private readonly LandSellingContext _dbContext;

        private ILotRepository _lotRepository;

        private IRealEstateRepository _realEstateRepository;

        private IRentRepository _rentRepository;

        private ISellingRepository _sellingRepository;

        private IBidRepository _bidRepository;

        private IFavoriteRepository _favoriteRepository;

        private IImageRepository _imageRepository;

        private IPriceCoefRepository _priceCoefRepository;

        private ICustomerRepository _customerRepository;

        private IManagerRepository _managerRepository;

        public LotUnitOfWork(LandSellingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ILotRepository LotRepository => _lotRepository ??= new LotRepository(_dbContext);

        public IRealEstateRepository RealEstateRepository => _realEstateRepository ??= new RealEstateRepository(_dbContext);

        public IRentRepository RentRepository => _rentRepository ??= new RentRepository(_dbContext);

        public ISellingRepository SellingRepository => _sellingRepository ??= new SellingRepository(_dbContext);

        public IBidRepository BidRepository => _bidRepository ??= new BidRepository(_dbContext);

        public IFavoriteRepository FavoriteRepository => _favoriteRepository ??= new FavoriteRepository(_dbContext);

        public IImageRepository ImageRepository => _imageRepository ??= new ImageRepository(_dbContext);

        public IPriceCoefRepository PriceCoefRepository => _priceCoefRepository ??= new PriceCoefRepository(_dbContext);

        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_dbContext);

        public IManagerRepository ManagerRepository => _managerRepository ??= new ManagerRepository(_dbContext);

        public async Task<int> Save() => await _dbContext.SaveChangesAsync();
    }
}
