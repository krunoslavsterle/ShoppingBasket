using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    /// <summary>
    /// Basket Facade.
    /// </summary>
    public class Basket : IBasket
    {
        private readonly IBasketCalculator _basketCalculator;
        private ICollection<BasketItem> _basketItems;

        public Basket(IBasketCalculator basketCalculator)
        {
            _basketCalculator = basketCalculator;
            _basketItems = new List<BasketItem>();
        }

        public IEnumerable<BasketItem> BasketItems => _basketItems;

        public void AddToBasket(BasketItem basketItem)
        {
            var existing = _basketItems.FirstOrDefault(p => p.Id == basketItem.Id);
            if (existing == null)
                _basketItems.Add(basketItem);
            else
                existing.UpdateQuantity(existing.Quantity + 1);
        }

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

        public BasketResult GetTotals()
        {
            return _basketCalculator.Calculate(BasketItems);
        }
    }
}
