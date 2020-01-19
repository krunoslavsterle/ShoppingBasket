using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShoppingBasket;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace UnitTests
{
    public class ShoppingBasketTestsFixture
    {
        public ShoppingBasketTestsFixture(ITestOutputHelper outputHelper)
        {
            // Setup DI.
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging((builder) => builder.AddXUnit(outputHelper));
            serviceCollection.AddShoppingBasketDependencies();

            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Create basket items.
            var bread = new BasketItem(Guid.NewGuid(), "Bread", 1);
            var butter = new BasketItem(Guid.NewGuid(), "Butter", 0.8M);
            var milk = new BasketItem(Guid.NewGuid(), "Milk", 1.15M);

            // Create discounts.
            var breadDiscount = new ProductDiscount("Buy two butters, get one bread at 50% off", 50);
            breadDiscount.AddCondition(butter.ProductId, 2);
            bread.AddDiscount(breadDiscount);

            var milkDiscount = new ProductDiscount("Buy three milks, get fourth for free", 100);
            milkDiscount.AddCondition(milk.ProductId, 3);
            milk.AddDiscount(milkDiscount);

            Products = new List<BasketItem> { bread, butter, milk };
        }

        public IServiceProvider ServiceProvider { get; }
        public IEnumerable<BasketItem> Products { get; }
    }

    public class MockLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine(state.ToString());
        }
    }
}
