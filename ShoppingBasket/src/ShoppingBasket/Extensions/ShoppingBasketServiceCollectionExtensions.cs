using Microsoft.Extensions.DependencyInjection;

namespace ShoppingBasket
{
    public static class ShoppingBasketServiceCollectionExtensions
    {
        public static IServiceCollection AddShoppingBasketDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBasket, Basket>();
            services.AddScoped<IBasketCalculator, BasketCalculator>();
            services.AddScoped<IDiscountCalculator, DiscountCalculator>();

            return services;
        }
    }
}
