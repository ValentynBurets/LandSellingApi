using Data.Contract.UnitOfWork;
using Data.Identity;
using Data.Identity.UnitOfWork;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AuthorisationUser>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<LandSellingIdentityContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var key = configuration.GetSection("Jwt").GetSection("Key").Value;

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });
        }
    }
}
