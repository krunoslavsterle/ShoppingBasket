using System.Collections.Generic;

namespace ShoppingBasket
{
    /// <summary>
    /// The BasketCalculator contract.
    /// </summary>
    public interface IBasketCalculator
    {
        /// <summary>
        /// Calculate the Basket totals.
        /// </summary>
        /// <param name="basketItems">The collection of <see cref="BasketItem"/>.</param>
        /// <returns></returns>
        BasketResult Calculate(IEnumerable<BasketItem> basketItems);
    }
}
