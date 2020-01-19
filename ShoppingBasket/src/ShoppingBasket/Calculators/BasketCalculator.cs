using System.Collections.Generic;

namespace ShoppingBasket
{
    /// <summary>
    /// The BasketCalculator implementation.
    /// </summary>
    public class BasketCalculator : IBasketCalculator
    {
        private readonly IDiscountCalculator _discountCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketCalculator"/> class.
        /// </summary>
        /// <param name="discountCalculator">The discount calculator.</param>
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
                var discountResult = _discountCalculator.Calculate(basketItems, bItem.ProductId);
                var baseAmount = bItem.UnitPrice * bItem.Quantity;
                var itemResult = new BasketItemResult
                {
                    ProductId = bItem.ProductId,
                    BaseAmount = baseAmount,
                    Quantity = bItem.Quantity,
                    UnitPrice = bItem.UnitPrice,
                    TotalAmount = baseAmount - discountResult.TotalDiscount,
                    DiscountResult = discountResult
                };

                result.BasketItemResults.Add(itemResult);
            }

            return result;
        }
    }
}
