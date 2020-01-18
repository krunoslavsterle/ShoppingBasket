using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    public interface IBasket
    {
        /// <summary>
        /// Gets the collection of <see cref="BasketItem"/> in Basket.
        /// </summary>
        IEnumerable<BasketItem> BasketItems { get;  }

        /// <summary>
        /// Adds a new <see cref="BasketItem"/> to the Basket.
        /// </summary>
        /// <param name="basketItem">The basket item.</param>
        void AddToBasket(BasketItem basketItem);

        /// <summary>
        /// Removes the <see cref="BasketItem"/> from the Basket.
        /// </summary>
        /// <param name="id">The basket item identifier.</param>
        void RemoveFromBasket(Guid id);

        /// <summary>
        /// Gets the Basket totals.
        /// </summary>
        /// <returns>The <see cref="BasketResult"/>.</returns>
        BasketResult GetTotals();
    }
}
