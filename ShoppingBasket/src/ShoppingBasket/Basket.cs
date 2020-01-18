using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    /// <summary>
    /// The Basket facade.
    /// </summary>
    public class Basket : IBasket
    {
        private readonly IBasketCalculator _basketCalculator;
        private ICollection<BasketItem> _basketItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="Basket"/> class.
        /// </summary>
        /// <param name="basketCalculator">The basket calculator.</param>
        public Basket(IBasketCalculator basketCalculator)
        {
            _basketCalculator = basketCalculator;
            _basketItems = new List<BasketItem>();
        }

        /// <summary>
        /// Gets the collection of <see cref="BasketItem"/> in Basket.
        /// </summary>
        public IEnumerable<BasketItem> BasketItems => _basketItems;

        /// <summary>
        /// Adds a new <see cref="BasketItem"/> to the Basket.
        /// </summary>
        /// <param name="basketItem">The basket item.</param>
        public void AddToBasket(BasketItem basketItem)
        {
            var existing = _basketItems.FirstOrDefault(p => p.Id == basketItem.Id);
            if (existing == null)
                _basketItems.Add(basketItem);
            else
                existing.UpdateQuantity(existing.Quantity + 1);
        }

        /// <summary>
        /// Removes the <see cref="BasketItem"/> from the Basket.
        /// </summary>
        /// <param name="id">The basket item identifier.</param>
        public void RemoveFromBasket(Guid id)
        {
            var existing = _basketItems.FirstOrDefault(p => p.Id == id);
            if (existing == null)
                return;

            if (existing.Quantity > 1)
                existing.UpdateQuantity(existing.Quantity - 1);
            else
                _basketItems.Remove(existing);
        }

        /// <summary>
        /// Gets the Basket totals.
        /// </summary>
        /// <returns>The <see cref="BasketResult"/>.</returns>
        public BasketResult GetTotals()
        {
            return _basketCalculator.Calculate(BasketItems);
        }
    }
}
