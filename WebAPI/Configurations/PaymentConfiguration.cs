using Braintree;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Configurations
{
    public static class PaymentConfiguration
    {
        public static void ConfigurePayment(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<BraintreeGateway>(g => new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = Configuration.GetSection("Payment").GetSection("MerchantID").Value,
                PublicKey= Configuration.GetSection("Payment").GetSection("PublicKey").Value,
                PrivateKey = Configuration.GetSection("Payment").GetSection("PrivateKey").Value,
            });
        }
    }
}
