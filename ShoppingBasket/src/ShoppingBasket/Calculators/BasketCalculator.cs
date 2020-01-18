using System.Collections.Generic;

namespace ShoppingBasket
{
    /// <summary>
    /// The BasketCalculator implementation.
    /// </summary>
    public class BasketCalculator : IBasketCalculator
    {
        private readonly IDiscountCalculator _discountCalculator;

        public BasketCalculator(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        /// <summary>
        /// Calculate the Basket totals.
        /// </summary>
        /// <param name="basketItems">The collection of <see cref="BasketItem"/>.</param>
        /// <returns></returns>
        public BasketResult Calculate(IEnumerable<BasketItem> basketItems)
        {
            var result = new BasketResult();

            foreach (var bItem in basketItems)
            {
                var discountResult = _discountCalculator.Calculate(basketItems, bItem.Id);
                var itemResult = new BasketItemResult
                {
                    BaskettemId = bItem.Id,
                    BaseAmount = bItem.UnitPrice * bItem.Quantity,
                    Quantity = bItem.Quantity,
                    UnitPrice = bItem.UnitPrice,
                    Discount = discountResult
                };

                result.BasketItemResults.Add(itemResult);
            }

            return result;
        }
    }
}
