﻿using Data.Contract.Repository;
using Data.Contract.Repository.Authentication;
using Data.Contract.Repository.LotManagement;
using Data.Contract.Repository.LotManagement.AgreementManagement;
using Data.Contract.UnitOfWork;
using Data.EF;
using Data.Repository;
using Data.Repository.Authentication;
using Data.Repository.LotManagement;
using Data.Repository.LotManagement.AgreementManagement;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class LotUnitOfWork : ILotUnitOfWork
    {
        private readonly LandSellingContext _dbContext;

        private ILotRepository _lotRepository;
        private IAgreementRepository _agreementRepository;

        private IBidRepository _bidRepository;

        private IImageRepository _imageRepository;
        private ILocationRepository _locationRepository;
        private IPaymentRepository _paymentRepository;
        private IPriceCoefRepository _priceCoefRepository;

        private IUserRepository _userRepository;
        private IAdminRepository _adminRepository;

        private ILotManagerRepository _lotManagerRepository;
        private IAgreementManagerRepository _agreementManagerRepository;

        public LotUnitOfWork(LandSellingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ILotRepository LotRepository => _lotRepository ??= new LotRepository(_dbContext);
        public IAgreementRepository AgreementRepository => _agreementRepository ??= new AgreementRepository(_dbContext);
        public IBidRepository BidRepository => _bidRepository ??= new BidRepository(_dbContext);
        public IImageRepository ImageRepository => _imageRepository ??= new ImageRepository(_dbContext);
        public ILocationRepository LocationRepository => _locationRepository ??= new LocationRepository(_dbContext);
        public IPaymentRepository PaymentRepository => _paymentRepository ??= new PaymentRepository(_dbContext);
        public IPriceCoefRepository PriceCoefRepository => _priceCoefRepository ??= new PriceCoefRepository(_dbContext);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);
        public IAdminRepository AdminRepository => _adminRepository ??= new AdminRepository(_dbContext);
        public ILotManagerRepository LotManagerRepository => _lotManagerRepository ??= new LotManagerRepository(_dbContext);
        public IAgreementManagerRepository AgreementManagerRepository => _agreementManagerRepository ??= new AgreementManagerRepository(_dbContext);
        public async Task<int> Save() => await _dbContext.SaveChangesAsync();
    }
}
