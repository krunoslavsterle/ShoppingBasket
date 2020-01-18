using ShoppingBasket;
using System.Linq;
using Xunit;
using Microsoft.Extensions.DependencyInjection;


namespace UnitTests
{
    public class ShoppingBasketTests
    {
        ShoppingBasketTestsFixture _fixture;
        public ShoppingBasketTests()
        {
            _fixture = new ShoppingBasketTestsFixture();
        }

        [Fact]
        public void Given_BreadButterAndMilk_When_Total_Then_SumPrice()
        {
            var basket = _fixture.ServiceProvider.GetRequiredService<IBasket>();

            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Bread"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Butter"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));

            var result = basket.GetTotals();
            Assert.True(result.TotalAmount == 2.95M);
        }

        [Fact]
        public void Given_TwoButterTwoBread_When_Total_Than_IncludeDiscount()
        {
            var basket = _fixture.ServiceProvider.GetRequiredService<IBasket>();

            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Bread"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Bread"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Butter"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Butter"));

            var result = basket.GetTotals();
            Assert.True(result.TotalAmount == 3.10M);
        }

        [Fact]
        public void Given_FourMilk_When_Total_Than_IncludeDiscount()
        {
            var basket = _fixture.ServiceProvider.GetRequiredService<IBasket>();

            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));

            var result = basket.GetTotals();
            Assert.True(result.TotalAmount == 3.45M);
        }

        [Fact]
        public void Given_TwoButterOneBreadEightMilk_When_Total_Than_IncludeDiscount()
        {
            var basket = _fixture.ServiceProvider.GetRequiredService<IBasket>();

            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Butter"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Butter"));

            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Bread"));

            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));
            basket.AddToBasket(_fixture.Products.First(p => p.Name == "Milk"));

            var result = basket.GetTotals();
            Assert.True(result.TotalAmount == 9M);
        }
    }
}
