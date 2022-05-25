using AutoMapper;
using Braintree;
using Business.Contract.Services.LotManagement.AgreementManagement.Payment;
using Business.Services.LotManagement.AgreementManagement;
using Business.Services.PaymentManagement.PaymentManagement;
using Data.Contract.Repository.Authentication;
using Data.Contract.UnitOfWork;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebAPI.Configurations;

namespace Business.Tests.BusinessTests.LotManagement.AgreementManagement
{
    [TestFixture]
    public class BraintreeConfigurationTest
    {
        private static IMapper mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(new MapperInitializer())));
        PaymentService paymentService;

        const string CustomerId = "123";
        Guid userId = new Guid("e15a1540-9225-429a-aa1c-028f0023451b");

        [SetUp]
        public void SetUp()
        {
            // Arrange
            IUserRepository paymentRepository =
            Mock.Of<IUserRepository>(iR => iR.GetUserCustomerIdAsync(It.IsAny<Guid>()) == Task.FromResult<string>(CustomerId));

            ILotUnitOfWork unitOfWork =
                Mock.Of<ILotUnitOfWork>(of => of.ImageRepository == null &&
                                      of.LotRepository == null &&
                                      of.UserRepository == null &&
                                      of.AdminRepository == null &&
                                      of.BidRepository == null &&
                                      of.PriceCoefRepository == null &&
                                      of.AgreementRepository == null &&
                                      of.PaymentRepository == paymentRepository);

            BraintreeGateway braintreeGateWay = new BraintreeGateway()
            {
                AccessToken = "123",
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "MerchantID",
                PublicKey = "PublicKey",
                PrivateKey = "PrivateKey"
            };

            IPaymentHelper paymentHelper = new PaymentHelper(braintreeGateWay, unitOfWork);

            paymentService = new PaymentService(mapper, unitOfWork, paymentHelper);
        }

        [Test]
        public void GetToken()
        {
            // Act
            var result = paymentService.GetToken(userId);

            // Assert
            Assert.That(result.Exception, !Is.Null);
        }
    }
}
