using Microsoft.Extensions.DependencyInjection;

namespace TheKrystalShip.PayPal.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPayPal(this IServiceCollection services)
        {

            return services;
        }
    }
}
