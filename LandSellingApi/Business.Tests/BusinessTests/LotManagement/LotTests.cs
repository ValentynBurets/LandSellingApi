using AutoMapper;
using Business.Contract.Model.LotManagement;
using Business.Services.LotManagement;
using Data.Contract.Repository.LotManagement;
using Data.Contract.UnitOfWork;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Configurations;

namespace Business.Tests.BusinessTests.LotManagement
{
    [TestFixture]
    public class LotTests
    {
        static LotDTO lotDTO = new LotDTO()
        {
            OwnerId = new Guid(""),
            ManagerId = new Guid(""),
            Status = "Open",
            Description = "description",
            BuyPrice = 100,
            MinBidPrice = 90,
            IsRent = false,
            IsAuction = false,
            Location =
            {
                Latitude = "20", 
                Longitude = "30",
                Country = " Ukraine",
                Region = "LvivRegion",
                City = "Lviv",
                Street = "Bandery"
            }

        };

        IEnumerable<LotDTO> lotDTOs = new List<LotDTO>()
        {
            lotDTO
        };

        private static IMapper mapper = new Mapper(new MapperConfiguration(cnf => cnf.AddProfile(new MapperInitializer())));
        LotService imageService;

        [SetUp]
        public void SetUp()
        {
            ILotRepository imageRepository =
                Mock.Of<ILotRepository>(iR => iR.GetByLotId(It.IsAny<Guid>()) == Task.FromResult(images) &&
                                                iR.Add(It.IsAny<Image>()) == Task.CompletedTask);

            ILotUnitOfWork unitOfWork =
                Mock.Of<ILotUnitOfWork>(of => of.ImageRepository == imageRepository &&
                                              of.LotRepository == null &&
                                              of.UserRepository == null &&
                                              of.AdminRepository == null &&
                                              of.BidRepository == null &&
                                              of.PriceCoefRepository == null &&
                                              of.AgreementRepository == null);

            imageService = new ImageService(mapper, unitOfWork);
        }

        [Test]
        public void CreateNewImage()
        {
            // Act
            var result = imageService.Create(imageDTO);

            // Assert
            Assert.That(result.Exception, Is.Null);
        }

        [Test]
        public void GetAllImagesByLotId()
        {
            // Act
            var result = imageService.GetAllByLotId(imageDTO.LotId);

            // Assert
            Assert.That(result.Result as IEnumerable<ImageDTO>, Is.EqualTo(returnImageDTO));
        }
    }
}
}
