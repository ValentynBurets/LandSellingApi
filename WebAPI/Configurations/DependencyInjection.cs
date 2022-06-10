using Data.Contract.UnitOfWork;
using Data.Identity;
using Data.Identity.UnitOfWork;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Business.Services.Authentication;
using Business.Contract.Services.Authentication;
using Business.Contract.Services.LotManagement;
using Business.Services.LotManagement;
using Business.Contract.Services.LotManagement.AgreementManagement;
using Business.Services.LotManagement.AgreementManagement;
using Business.Services.PaymentManagement.PaymentManagement;
using Business.Contract.Services.LotManagement.AgreementManagement.Payment;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ILotUnitOfWork, LotUnitOfWork>();
            services.AddTransient<IAuthentificationUnitOfWork, AuthentificationUnitOfWork>();

            //add here new services
            services.AddTransient<ILotService, LotService>();
            services.AddTransient<IPriceCoefService, PriceCoefService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IBidService, BidService>();
            services.AddTransient<IAgreementService, AgreementService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentHelper, PaymentHelper>();

            services.AddTransient<IProfileRegistrationService, ProfileRegistrationService>();

            services.AddTransient<IProfileManager, ProfileManager<AuthorisationUser>>();
            services.AddTransient<IProfileDataService, ProfileDataService>();

            return services;
        }
    }
}
