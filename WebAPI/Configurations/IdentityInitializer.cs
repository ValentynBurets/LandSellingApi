using Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Configurations
{
    public static class IdentityInitializer
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AuthorisationUser>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<LandSellingIdentityContext>().AddDefaultTokenProviders();

            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<LandSellingIdentityContext>();
            identityBuilder.AddSignInManager<SignInManager<AuthorisationUser>>();
        }
    }
}
