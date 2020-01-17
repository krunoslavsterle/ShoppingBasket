using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    /// <summary>
    /// Basket Facade.
    /// </summary>
    public class Basket
    {
        private ICollection<BasketItem> _basketItems;

        public Basket()
        {
            _basketItems = new List<BasketItem>();
        }

        public Basket(ICollection<BasketItem> basketItems)
        {
            _basketItems = basketItems;
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

        public void GetTotals()
        {
            // TODO: IMPLEMENT THIS.
        }
    }
}
