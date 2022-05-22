using AutoMapper;
using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Agreement;
using Business.Services.LotManagement.AgreementManagement;
using Data.Contract.Repository.LotManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity;
using Domain.Entity.Constants;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebAPI.Configurations;

namespace Business.Tests.BusinessTests.LotManagement.AgreementManagement
{
    [TestFixture]
    public class AgreementTest
    {
        static CreateAgreementDTO createAgreementDTO = new CreateAgreementDTO()
        {
            LotId = new Guid("e15a1540-9225-429a-aa1c-028f0023451b"),
            CustomerId = new Guid(""),
            Description = "Agreement description",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };

        static AgreementDTO agreementDTO = new AgreementDTO()
        {
            LotId = new Guid("e15a1540-9225-429a-aa1c-028f0023451b"),
            CustomerId = new Guid(""),
            Status = "Open",
            Description = "Agreement description",
            CreationDate = DateTime.Now,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };

        static Agreement agreement = new Agreement()
        {
            LotId = new Guid("e15a1540-9225-429a-aa1c-028f0023451b"),
            CustomerId = new Guid(""),
            Status = State.Open,
            Description = "Agreement description",
            CreationDate = DateTime.Now,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };

        private static IMapper mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(new MapperInitializer())));
        AgreementService agreementService;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            IAgreementRepository agreementRepository =
            Mock.Of<IAgreementRepository>(iR => iR.Add(It.IsAny<Agreement>()) == Task.CompletedTask &&
                                                iR.GetByLotId(It.IsAny<Guid>()) == Task.FromResult(agreement));

            ILotUnitOfWork unitOfWork =
                Mock.Of<ILotUnitOfWork>(of => of.ImageRepository == null &&
                                      of.LotRepository == null &&
                                      of.UserRepository == null &&
                                      of.AdminRepository == null &&
                                      of.BidRepository == null &&
                                      of.PriceCoefRepository == null &&
                                      of.AgreementRepository == agreementRepository);

            agreementService = new AgreementService(mapper, unitOfWork);
        }

        [Test]
        public void CreateNewAgreement()
        {
            // Act
            var result = agreementService.Create(createAgreementDTO);

            // Assert
            Assert.That(result.Exception, Is.Null);
        }

        [Test]
        public void GetByLotId()
        {
            // Act
            var result = agreementService.GetByLotId(agreementDTO.LotId);

            // Assert
            Assert.That(result.Result, Is.EqualTo(agreementDTO));
        }
    }
}