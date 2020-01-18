using ShoppingBasket;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    public class ShoppingBasketTestsFixture
    {
        public ShoppingBasketTestsFixture()
        {
            var bread = new BasketItem(Guid.NewGuid(), "Bread", 1);
            var butter = new BasketItem(Guid.NewGuid(), "Butter", 0.8M);
            var milk = new BasketItem(Guid.NewGuid(), "Milk", 1.15M);

            var breadDiscount = new ProductDiscount("Buy two butters, get one bread at 50% off", 50);
            breadDiscount.AddCondition(butter.Id, 2);
            bread.AddDiscount(breadDiscount);

            var milkDiscount = new ProductDiscount("Buy three milks, get fourth for free", 100);
            milkDiscount.AddCondition(milk.Id, 3);
            milk.AddDiscount(milkDiscount);

            Products = new List<BasketItem> { bread, butter, milk };
        }

        public IEnumerable<BasketItem> Products { get; }

        public Basket CreateBasket()
        {
            var discountCalculator = new DiscountCalculator();
            var basketCalculator = new BasketCalculator(discountCalculator);

            return new Basket(basketCalculator);
        }
    }
}
