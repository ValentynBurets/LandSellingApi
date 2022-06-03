using AutoMapper;
using Business.Contract.Model;
using Business.Contract.Services.Authentication;
using Business.Services.Authentication;
using Data.Contract.Repository.Authentication;
using Data.Contract.UnitOfWork;
using Data.Identity;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using Xunit;

namespace AuthorizationTests.UserManagement
{
    public class ProfileDataServiceTests
    {
        [Fact]
        public async void GetUserProfileInfoById_CustomerId_EqualCustomerProfileInfoModel()
        {
            // Arrange
            User testedUser = new User(new Guid()) { Name = "Valentyn", SurName = "Burets" };

            var userRepositoryStub = new Mock<IUserRepository>();
            userRepositoryStub.Setup(obj => obj.GetByIdLink(It.IsAny<Guid>()))
                .ReturnsAsync(testedUser);

            var authentificationUnitOfWorkStub = new Mock<IAuthentificationUnitOfWork>();
            authentificationUnitOfWorkStub.Setup(obj => obj.UserRepository)
                .Returns(userRepositoryStub.Object);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<User, ProfileInfoModel>());
            var mapper = new Mapper(mapperConfiguration);
            
            var store = new Mock<IUserStore<AuthorisationUser>>();
            IProfileManager _profileManager = new ProfileManager<AuthorisationUser>(store.Object, null, null, null, null, null, null, null, null);
            ProfileDataService ProfileDataService = new ProfileDataService(authentificationUnitOfWorkStub.Object, mapper, _profileManager);
            // Act

            var expect = await ProfileDataService.GetUserProfileInfoById(testedUser.Id);

            // Assert
            Assert.NotNull(expect);
            Assert.Equal(expect.Name, testedUser.Name);
            Assert.Equal(expect.Surname, testedUser.SurName);
        }

        [Fact]
        public async void GetAdminProfileInfoById_CustomerId_EqualCustomerProfileInfoModel()
        {
            // Arrange
            Admin testedAdmin = new Admin(new Guid()) { Name = "Valentyn", SurName = "Burets" };

            var adminRepositoryStub = new Mock<IAdminRepository>();
            adminRepositoryStub.Setup(obj => obj.GetByIdLink(It.IsAny<Guid>()))
                .ReturnsAsync(testedAdmin);

            var authentificationUnitOfWork = new Mock<IAuthentificationUnitOfWork>();
            authentificationUnitOfWork.Setup(obj => obj.AdminRepository)
                .Returns(adminRepositoryStub.Object);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Admin, ProfileInfoModel>());
            var mapper = new Mapper(mapperConfiguration);

            var store = new Mock<IUserStore<AuthorisationUser>>();
            IProfileManager _profileManager = new ProfileManager<AuthorisationUser>(store.Object, null, null, null, null, null, null, null, null);

            ProfileDataService ProfileDataService = new ProfileDataService(authentificationUnitOfWork.Object, mapper, _profileManager);

            // Act

            var expect = await ProfileDataService.GetAdminProfileInfoById(testedAdmin.Id);

            // Assert
            Assert.NotNull(expect);
            Assert.Equal(expect.Name, testedAdmin.Name);
            Assert.Equal(expect.Surname, testedAdmin.SurName);
        }

        [Fact]
        public async void UpdateAdminProfileInfoById_ProfileInfoModelAndCustomerId_UpdatedCustomer()
        {
            // Arrange
            Admin testedAdmin = new Admin(new Guid()) { Name = "Valentyn", SurName = "Burets" };
            ProfileInfoModel newProfileInfo = new ProfileInfoModel { Name = "Valentyn", SurName = "Burets" };

            var adminRepositoryStub = new Mock<IAdminRepository>();
            adminRepositoryStub.Setup(obj => obj.GetByIdLink(It.IsAny<Guid>()))
                .ReturnsAsync(testedAdmin);

            var authentificationUnitOfWork = new Mock<IAuthentificationUnitOfWork>();
            authentificationUnitOfWork.Setup(obj => obj.AdminRepository)
                .Returns(adminRepositoryStub.Object);

            var mapperFake = new Mock<IMapper>();

            var store = new Mock<IUserStore<AuthorisationUser>>();
            IProfileManager _profileManager = new ProfileManager<AuthorisationUser>(store.Object, null, null, null, null, null, null, null, null);

            ProfileDataService ProfileDataService = new ProfileDataService(authentificationUnitOfWork.Object, mapperFake.Object, _profileManager);

            // Act

            await ProfileDataService.UpdateAdminProfileInfoById(newProfileInfo, testedAdmin.Id);

            // Assert
            Assert.Equal(testedAdmin.Name, newProfileInfo.Name);
            Assert.Equal(testedAdmin.SurName, newProfileInfo.SurName);
        }
    }
}