using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Identity;
using WebAPI.Configurations;
using Xunit;
using Moq;
using Data.Contract.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Domain.Entity;
using Business.Services.Authentication;

namespace AuthorizationTests.UserManagement
{
    public class ProfileRegistrationServiceTest
    {
        private static IMapper _mapper;

        private static readonly AuthorisationUser systemUserElem = new AuthorisationUser();

        private static readonly List<List<string>> roleList = new() { new() { "User" }, new() { "Admin" }, new() { "Not" } };

        public ProfileRegistrationServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperInitializer());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Theory]
        [InlineData(0, "Valentyn", "Burets")]
        [InlineData(1, "Valentyn2", "Burets2")]
        [InlineData(2, "Valentyn3", "Burets3")]
        public async void CreateProfileTest(int id, string Name, string LastName)
        {
            //Average
            var mockIAuthentificationUnitOfWork = new Mock<IAuthentificationUnitOfWork>();

            var store = new Mock<IUserStore<AuthorisationUser>>();

            var mockUserManager = new Mock<UserManager<AuthorisationUser>>(store.Object, null, null, null, null, null, null, null, null);

            mockUserManager.Setup(systemUser => systemUser.GetRolesAsync(It.IsAny<AuthorisationUser>())).ReturnsAsync(roleList[id]);

            mockIAuthentificationUnitOfWork.Setup(mockIOrderUnitOfWork => mockIOrderUnitOfWork.UserRepository.Add(It.IsAny<User>()));
            mockIAuthentificationUnitOfWork.Setup(mockIOrderUnitOfWork => mockIOrderUnitOfWork.AdminRepository.Add(It.IsAny<Admin>()));

            mockIAuthentificationUnitOfWork.Setup(mockIOrderUnitOfWork => mockIOrderUnitOfWork.Save());

            ProfileRegistrationService profileRegistrationService = new(mockUserManager.Object, mockIAuthentificationUnitOfWork.Object);
            //Act
            var result = await profileRegistrationService.CreateProfile(systemUserElem, Name, LastName);
            //Assert
            Assert.True(result);
        }

        [Xunit.Theory]
        [InlineData("Valentyn", "Burets")]
        public async Task CreateProfileTestFalse(string Name, string LastName)
        {
            //Average
            var mockIOrderUnitOfWork = new Mock<IAuthentificationUnitOfWork>();

            var store = new Mock<IUserStore<AuthorisationUser>>();

            string expectedMessege = "Role is not set";

            var mockUserManager = new Mock<UserManager<AuthorisationUser>>(store.Object, null, null, null, null, null, null, null, null);

            mockUserManager.Setup(systemUser => systemUser.GetRolesAsync(It.IsAny<AuthorisationUser>())).ReturnsAsync(new List<string> { });

            ProfileRegistrationService profileRegistrationService = new(mockUserManager.Object, mockIOrderUnitOfWork.Object);
            //Act
            Action act = () => profileRegistrationService.CreateProfile(systemUserElem, Name, LastName);
            //Assert
            Exception exception = await Assert.ThrowsAsync<Exception>(() => profileRegistrationService.CreateProfile(systemUserElem, Name, LastName));
            Assert.Equal(expectedMessege, exception.Message);
        }
    }
}
