using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    /// <summary>
    /// The DiscountCalculator contract.
    /// </summary>
    public interface IDiscountCalculator
    {
        /// <summary>
        /// Calculates the discounts for a given product.
        /// </summary>
        /// <param name="basketItems">The collection of <see cref="BasketItem"/>.</param>
        /// <param name="productId">The product identifier for which to calculate discounts.</param>
        /// <returns></returns>
        DiscountResult Calculate(IEnumerable<BasketItem> basketItems, Guid productId);
    }
}
