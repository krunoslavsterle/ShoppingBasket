using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    /// <summary>
    /// The BasketCalculator implementation.
    /// </summary>
    public class BasketCalculator : IBasketCalculator
    {
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
                var itemResult = new BasketItemResult
                {
                    BaskettemId = bItem.Id,
                    BaseAmount = bItem.UnitPrice * bItem.Quantity,
                    Quantity = bItem.Quantity,
                    UnitPrice = bItem.UnitPrice
                };

                result.BasketItemResults.Add(itemResult);
                // calculate discounts...

            }

            return result;
        }
    }
}
