using Microsoft.Extensions.DependencyInjection;

namespace SnakeAndLadders.Library
{
    public static class SnakesAndLaddersServiceCollectionExtensions
    {
        public static IServiceCollection AddSnakeAndLaddersServices(this IServiceCollection services)
        {
            services.AddSingleton<IDiceThrower, DiceThrower>();
            services.AddSingleton<GameManager>();

            return services;
        }
    }
}
