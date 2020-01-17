using ShoppingBasket;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ShoppingBasketTests
    {
        [Fact]
        public void Given_BreadButterAndMilk_When_Total_Then_SumPrice()
        {
            var basketCalculator = new BasketCalculator();

            var bread = new BasketItem(Guid.NewGuid(), "Bread", 1);
            var butter = new BasketItem(Guid.NewGuid(), "Butter", 0.8M);
            var milk = new BasketItem(Guid.NewGuid(), "Milk", 1.15M);

            var cart = new Basket(basketCalculator);
            cart.AddToBasket(bread);
            cart.AddToBasket(butter);
            cart.AddToBasket(milk);

            var result = cart.GetTotals();
            Assert.True(result.BaseAmount == 2.95M);
        }

        [Fact]
        public void Given_TwoButterTwoBread_When_Total_Than_IncludeDiscount()
        {
            Assert.True(false);
        }

        [Fact]
        public void Given_FourMilk_When_Total_Than_IncludeDiscount()
        {
            Assert.True(false);
        }

        [Fact]
        public void Given_TwoButterOneBreadEightMilk_When_Total_Than_IncludeDiscount()
        {
            Assert.True(false);
        }
    }
}
